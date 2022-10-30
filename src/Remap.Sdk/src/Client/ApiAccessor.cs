using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
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
        #region Fields

        internal static IList<JsonConverter> DefaultConverters = new JsonConverter[]
        {
            new StringEnumConverter(),
            new AbstractProductConverter(),
            new AssortmentConverter(),
            new AttributeValueConverter(),
            new BarcodeConverter(),
            new DiscountConverter(),
            new PaymentDocumentConverter()
        };

        private JsonSerializerSettings _defaultReadSettings = new JsonSerializerSettings
        {
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            Converters = DefaultConverters
        };

        private JsonSerializerSettings _defaultWriteSettings = new JsonSerializerSettings
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
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));

            Path = relativePath;
            Credentials = credentials;
            Client = httpClient;
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Deserializes the model into the JSON string.
        /// </summary>
        /// <param name="obj">The model.</param>
        /// <returns>The JSON string.</returns>
        internal virtual string Serialize(object obj)
        {
            try
            {
                return obj != null ? JsonConvert.SerializeObject(obj, _defaultWriteSettings) : null;
            }
            catch (Exception e)
            {
                throw new ApiException(500, e.Message);
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
        {
            var httpResponse = await InternalCallAsync(context, callerName);
            var model = (TResponse)await DeserializeAsync(httpResponse, typeof(TResponse));

            return new ApiResponse<TResponse>((int)httpResponse.StatusCode, httpResponse.Headers
                .ToDictionary(nameValues => nameValues.Key, nameValues => string.Join(", ", nameValues.Value)), model);
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

            return new ApiResponse((int)httpResponse.StatusCode, httpResponse.Headers
                .ToDictionary(nameValues => nameValues.Key, nameValues => string.Join(", ", nameValues.Value)));
        }

        /// <summary>
        /// Creates the entity.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        /// <typeparam name="TResponse">The type of the response model.</typeparam>
        /// <returns>The <see cref="Task"/> containing the API response with the created entity.</returns>
        protected virtual Task<ApiResponse<TResponse>> CreateAsync<TResponse>(TResponse entity)
            where TResponse : MetaEntity
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var requestContext = new RequestContext(HttpMethod.Post)
                .WithBody(entity);

            return CallAsync<TResponse>(requestContext);
        }

        /// <summary>
        /// Deletes the entity.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        /// <returns>The <see cref="Task"/> containing the API response.</returns>
        protected virtual Task<ApiResponse> DeleteAsync<TResponse>(TResponse entity)
            where TResponse : MetaEntity
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var id = entity.GetId();
            if (!id.HasValue)
                throw new InvalidOperationException("The entity id cannot be null.");

            return DeleteByIdAsync(id.Value);
        }

        /// <summary>
        /// Deletes the entity by specified id.
        /// </summary>
        /// <param name="id">The entity id.</param>
        /// <returns>The <see cref="Task"/> containing the API response.</returns>
        protected virtual Task<ApiResponse> DeleteByIdAsync(Guid id)
        {
            var requestContext = new RequestContext($"{Path}/{id}", HttpMethod.Delete);

            return CallAsync(requestContext);
        }

        /// <summary>
        /// Deserializes the JSON string into a proper object.
        /// </summary>
        /// <param name="response">The HTTP response message.</param>
        /// <param name="type">The object type.</param>
        /// <returns>The <see cref="Task"/> containing the parsed data.</returns>
        protected virtual async Task<object> DeserializeAsync(HttpResponseMessage response, Type type)
        {
            if (response == null)
                throw new ArgumentNullException(nameof(response));

            if (type == typeof(Stream))
                return await response.Content.ReadAsStreamAsync();

            var responseContent = await response.Content.ReadAsStringAsync();

            try
            {
                return await Task.Run(() => JsonConvert.DeserializeObject(responseContent, type, _defaultReadSettings));
            }
            catch (Exception e)
            {
                throw new ApiException(500, $"Error when deserializing HTTP response content. HTTP status code - 500. {e.Message}");
            }
        }

        /// <summary>
        /// Gets the <see cref="ApiResponse{TResponse}" /> with specified query (optional).
        /// </summary>
        /// <param name="query">The query builder.</param>
        /// <typeparam name="TResponse">The type of the response model.</typeparam>
        /// <returns>The <see cref="Task"/> containing the API response with the response model.</returns>
        protected virtual Task<ApiResponse<TResponse>> GetAsync<TResponse>(ApiParameterBuilder query = null)
        {
            var requestContext = new RequestContext();

            if (query != null)
                requestContext.WithQuery(query.Build());

            return CallAsync<TResponse>(requestContext);
        }

        /// <summary>
        /// Gets the <see cref="ApiResponse{TResponse}" /> by id and specified query (optional).
        /// </summary>
        /// <param name="id">The entity id.</param>
        /// <param name="query">The query builder.</param>
        /// <typeparam name="TResponse">The type of the response model.</typeparam>
        /// <returns>The <see cref="Task"/> containing the API response with the response model.</returns>
        protected virtual Task<ApiResponse<TResponse>> GetByIdAsync<TResponse>(Guid id, ApiParameterBuilder query = null)
        {
            var requestContext = new RequestContext($"{Path}/{id}");

            if (query != null)
                requestContext.WithQuery(query.Build());

            return CallAsync<TResponse>(requestContext);
        }

        /// <summary>
        /// Executes the HTTP request asynchronously.
        /// </summary>
        /// <param name="context">The request context to prepare HTTP request.</param>
        /// <param name="callerName">The caller name.</param>
        /// <returns>The <see cref="Task"/> containing the HTTP response.</returns>
        protected virtual async Task<HttpResponseMessage> InternalCallAsync(RequestContext context, [CallerMemberName] string callerName = "")
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
                catch (Exception e)
                {
                    throw new ApiException(500, $"Error when calling '{callerName}'. HTTP status code - 500. {e.Message}");
                }

                int status = (int)response.StatusCode;
                if (status == 301 || status == 303 || status >= 400)
                {
                    var errorMessage = $"Error calling '{callerName}'. HTTP status code - {status}\n";

                    ApiErrorsResponse errorsResponse = null;
                    if (response.Content.Headers.ContentType.MediaType.Contains("application/json"))
                    {
                        try
                        {
                            errorsResponse = (ApiErrorsResponse)await DeserializeAsync(response, typeof(ApiErrorsResponse));
                        }
                        catch (Exception) { }
                    }

                    if (errorsResponse?.Errors?.Any() == true)
                    {
                        var details = errorsResponse.Errors
                            .Select(error => $"Error code: {error.Code}\n Error description: {error.Error}\n More info: {error.MoreInfo}\n");
                        errorMessage += string.Join("\n", details);
                    }

                    var headers = response.Headers
                        .ToDictionary(nameValues => nameValues.Key, nameValues => string.Join(", ", nameValues.Value));
                    throw new ApiException(status, errorMessage, headers, errorsResponse?.Errors);
                }

                request.Content?.Dispose();
            }

            return response;
        }

        /// <summary>
        /// Updates the entity.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <typeparam name="TResponse">The type of the response model.</typeparam>
        /// <returns>The <see cref="Task"/> containing the API response with the updated entity.</returns>
        protected virtual Task<ApiResponse<TResponse>> UpdateAsync<TResponse>(TResponse entity)
            where TResponse : MetaEntity
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var id = entity.GetId();
            if (!id.HasValue)
                throw new InvalidOperationException("The entity id cannot be null.");

            var requestContext = new RequestContext($"{Path}/{id}", HttpMethod.Put)
                .WithBody(entity);

            return CallAsync<TResponse>(requestContext);
        }

        #endregion Methods

        #region Utilities

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

            var baseAddress = Client.BaseAddress == null
                ? new Uri(ApiDefaults.DEFAULT_BASE_PATH)
                : Client.BaseAddress;

            if (!Uri.TryCreate(baseAddress, relativeUri, out var uri))
                throw new ApiException(500, $"Cannot create the HTTP request URI.");

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

        #endregion Utilities
    }
}