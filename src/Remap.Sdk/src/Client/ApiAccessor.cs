using Confiti.MoySklad.Remap.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Confiti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents a abstraction to interact with the API endpoint(s).
    /// </summary>
    public abstract class ApiAccessor
    {
        private static readonly IList<JsonConverter> DefaultConverters = new JsonConverter[]
        {
            new StringEnumConverter(),
            new AbstractProductConverter(),
            new AssortmentConverter(),
            new AttributeValueConverter(),
            new BarcodeConverter(),
            new DiscountConverter(),
            new PaymentDocumentConverter()
        };

        #region Fields

        internal readonly JsonSerializerSettings _defaultReadSettings = new JsonSerializerSettings
        {
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            Converters = DefaultConverters
        };

        internal readonly JsonSerializerSettings _defaultWriteSettings = new JsonSerializerSettings
        {
            DateFormatString = ApiDefaults.DEFAULT_DATETIME_FORMAT,
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = DefaultMoySkladContractResolver.Instance,
            Converters = DefaultConverters
        };

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the HTTP client.
        /// </summary>
        internal HttpClient Client { get; set; }

        /// <summary>
        /// Gets the MoySklad credentials.
        /// </summary>
        internal MoySkladCredentials Credentials { get; set; }

        /// <summary>
        /// Gets the API endpoint relative path.
        /// </summary>
        internal string Path { get; }

        #endregion Properties

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ApiAccessor" /> class
        /// with the API endpoint relative path, the HTTP client and the MoySklad credentials (optional).
        /// </summary>
        /// <param name="relativePath">The API endpoint relative path.</param>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public ApiAccessor(string relativePath, HttpClient httpClient, MoySkladCredentials credentials = null)
        {
            Path = relativePath;
            Credentials = credentials;
            Client = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Deserializes the <see cref="HttpResponseMessage"/> into a <typeparamref name="TResponse"/>.
        /// </summary>
        /// <param name="response">The HTTP response message.</param>
        /// <returns>The <see cref="Task"/> containing the object or null.</returns>
        internal virtual async Task<TResponse> DeserializeAsync<TResponse>(HttpResponseMessage response)
            where TResponse : class
        {
            return await response.DeserializeAsync(typeof(TResponse), _defaultReadSettings) as TResponse;
        }

        /// <summary>
        /// Deserializes the model into the JSON string.
        /// </summary>
        /// <param name="obj">The model.</param>
        /// <returns>The JSON string.</returns>
        internal virtual string Serialize(object obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj, _defaultWriteSettings);
            }
            catch (JsonException e)
            {
                throw new ApiException($"Error when serializing '{obj.GetType()}'.", e);
            }
        }

        /// <summary>
        /// Executes the HTTP request asynchronously.
        /// </summary>
        /// <param name="context">The request context to prepare HTTP request.</param>
        /// <param name="callerName">The caller name.</param>
        /// <typeparam name="TResponse">The type of the response model.</typeparam>
        /// <returns>The <see cref="Task"/> containing the API response with the response model.</returns>
        protected virtual async Task<ApiResponse<TResponse>> CallAsync<TResponse>(RequestContext context, [CallerMemberName] string callerName = "")
            where TResponse : class
        {
            var httpResponse = await InternalCallAsync(context, callerName);
            var model = await DeserializeAsync<TResponse>(httpResponse);

            return new ApiResponse<TResponse>((int)httpResponse.StatusCode, httpResponse.Headers.ToDictionary(), model);
        }

        /// <summary>
        /// Executes the HTTP request asynchronously.
        /// </summary>
        /// <param name="context">The request context to prepare HTTP request.</param>
        /// <param name="callerName">The caller name.</param>
        /// <returns>The <see cref="Task"/> containing the API response.</returns>
        protected virtual async Task<ApiResponse> CallAsync(RequestContext context, [CallerMemberName] string callerName = "")
        {
            var httpResponse = await InternalCallAsync(context, callerName);

            return new ApiResponse((int)httpResponse.StatusCode, httpResponse.Headers.ToDictionary());
        }

        #endregion Methods

        #region Utilities

        /// <summary>
        /// Creates the <see cref="HttpRequestMessage"/> by <see cref="RequestContext"/>
        /// </summary>
        /// <param name="context">The request context to prepare HTTP request.</param>
        /// <returns>The <see cref="HttpRequestMessage"/>.</returns>
        /// <exception cref="ApiException">Throws if <paramref name="context"/> is null.</exception>
        private HttpRequestMessage CreateHttpRequest(RequestContext context)
        {
            var relativeUri = string.IsNullOrEmpty(context.Path) ? Path : context.Path;
            if (context.Query?.Any() == true)
            {
                var parsedQuery = HttpUtility.ParseQueryString(string.Empty);
                foreach (var keyValuePair in context.Query)
                    parsedQuery[keyValuePair.Key] = keyValuePair.Value;

                relativeUri += $"?{parsedQuery}";
            }

            var baseAddress = Client.BaseAddress ?? new Uri(ApiDefaults.DEFAULT_BASE_PATH);
            if (!Uri.TryCreate(baseAddress, relativeUri, out var uri))
                throw new ApiException("Cannot create the HTTP request URI.");

            var request = new HttpRequestMessage(context.Method, uri);

            if (Credentials != null)
            {
                if (!string.IsNullOrEmpty(Credentials.AccessToken))
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Credentials.AccessToken);
                else if (!string.IsNullOrEmpty(Credentials.Username) && !string.IsNullOrEmpty(Credentials.Password))
                {
                    var credentialsData = Encoding.ASCII.GetBytes($"{Credentials.Username}:{Credentials.Password}");
                    var convertedCredentialsData = Convert.ToBase64String(credentialsData);
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", convertedCredentialsData);
                }
            }

            foreach (var header in context.Headers)
                request.Headers.Add(header.Key, header.Value);

            if (!Client.DefaultRequestHeaders.Contains("UserAgent"))
                request.Headers.Add("UserAgent", ApiDefaults.DEFAULT_USER_AGENT);

            if (!Client.DefaultRequestHeaders.Contains("Accept"))
                request.Headers.Add("Accept", "*/*");

            if (context.Body != null)
            {
                var serializedContent = Serialize(context.Body);
                request.Content = new StringContent(serializedContent, Encoding.UTF8, "application/json");
            }

            return request;
        }

        /// <summary>
        /// Executes the HTTP request asynchronously.
        /// </summary>
        /// <param name="context">The request context to prepare HTTP request.</param>
        /// <param name="callerName">The caller name.</param>
        /// <returns>The <see cref="Task"/> containing the HTTP response.</returns>
        private async Task<HttpResponseMessage> InternalCallAsync(RequestContext context, [CallerMemberName] string callerName = "")
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            HttpResponseMessage response = null;

            using (var request = CreateHttpRequest(context))
            {
                try
                {
                    response = await Client.SendAsync(request);
                }
                catch (HttpRequestException e)
                {
                    throw new ApiException($"Error when calling '{GetType().Name}.{callerName}'.", e);
                }

                var status = (int)response.StatusCode;
                if (status == 301 || status == 303 || status >= 400)
                    throw await response.ToApiException($"{GetType().Name}.{callerName}", _defaultReadSettings);
            }

            return response;
        }

        #endregion Utilities
    }
}