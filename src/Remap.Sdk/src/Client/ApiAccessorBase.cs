using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Extensions;
using Confiti.MoySklad.Remap.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using RestSharp.Serialization;

namespace Confiti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents a base API Accessor to interact with the API endpoint.
    /// </summary>
    public abstract class ApiAccessorBase : IApiAccessor
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
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = DefaultMoySkladContractResolver.Instance,
            Converters = DefaultConverters
        };

        private RestClient _restClient;
        private ExceptionFactory _exceptionFactory;
        private AuthenticatorFactory _authenticatorFactory;
            
        #endregion

        #region Properties

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path.</value>
        public virtual string BasePath => _restClient.BaseUrl.ToString();

        /// <summary>
        /// Gets the relative path to the endpoint.
        /// </summary>
        /// <value>The relative path.</value>
        public virtual string Path { get; }

         /// <summary>
        /// Gets or sets the <see cref="Configuration"/>.
        /// </summary>
        /// <value>The API configuration.</value>
        public virtual Configuration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public virtual ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                    throw new InvalidOperationException($"Multicast delegate for {nameof(ExceptionFactory)} is unsupported.");
                
                return _exceptionFactory;
            }
            set 
            { 
                _exceptionFactory = value; 
            }
        }

        /// <summary>
        /// Provides a factory method hook for the creation of authenticator.
        /// </summary>
        public virtual AuthenticatorFactory AuthenticatorFactory
        {
            get
            {
                if (_authenticatorFactory != null && _authenticatorFactory.GetInvocationList().Length > 1)
                    throw new InvalidOperationException($"Multicast delegate for {nameof(AuthenticatorFactory)} is unsupported.");
                
                return _authenticatorFactory;
            }
            set 
            { 
                _authenticatorFactory = value; 
            }
        }
            
        #endregion
    
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ApiAccessorBase" /> class
        /// with the API endpoint relative path, base API path 
        /// and the API configuration is specified (or use <see cref="Configuration.Default" />).
        /// </summary>
        /// <param name="relativePath">The API endpoint relative path.</param>
        /// <param name="basePath">The base API path.</param>
        /// <param name="configuration">The API configuration.</param>
        public ApiAccessorBase(string relativePath, string basePath = null, Configuration configuration = null)
        {
            Configuration = configuration ?? Configuration.Default;
            Path = relativePath ?? throw new ArgumentNullException(nameof(relativePath));
            ExceptionFactory = Configuration.DefaultExceptionFactory;
            AuthenticatorFactory = Configuration.DefaultAuthenticatorFactory;
            
            if (Uri.TryCreate(basePath, UriKind.Absolute, out var baseUrl))
                _restClient = new RestClient(baseUrl);
            else
                _restClient = new RestClient(Configuration.DEFAULT_BASE_PATH);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepares the request context with default values.
        /// </summary>
        /// <param name="method">The HTTP method type.</param>
        /// <param name="path">The relative path to the endpoint.</param>
        /// <returns>The request context.</returns>
        protected virtual RequestContext PrepareRequestContext(Method method = Method.GET, string path = null)
        {
            return new RequestContext(path ?? Path, method)
                .WithContentType(ContentType.Json)
                .WithAccept("*/*")
                .WithHeaders(Configuration.DefaultHeaders);
        }

        /// <summary>
        /// Deserializes the model into the JSON string.
        /// </summary>
        /// <param name="obj">The model.</param>
        /// <returns>The JSON string.</returns>
        protected virtual string Serialize(object obj)
        {
            _defaultWriteSettings.DateFormatString = Configuration.DateTimeFormat;
            
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
        /// Deserializes the JSON string into a proper object.
        /// </summary>
        /// <param name="response">The REST response.</param>
        /// <param name="type">The object type.</param>
        /// <returns>The parsed model.</returns>
        protected virtual object Deserialize(IRestResponse response, Type type)
        {
            if (response == null)
                throw new ArgumentNullException(nameof(response));
            
            if (type == typeof(byte[]))
                return response.RawBytes;

            try
            {
                return JsonConvert.DeserializeObject(response.Content, type, _defaultReadSettings);
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
        protected async virtual Task<ApiResponse<TResponse>> CallAsync<TResponse>(RequestContext context, [CallerMemberName] string callerName = "")
        {
            var response = await InternalCallAsync(context, callerName);
            var model = (TResponse)Deserialize(response, typeof(TResponse));

            return response.ToApiResponse(model);
        }

        /// <summary>
        /// Executes the HTTP request asynchronously.
        /// </summary>
        /// <param name="context">The request context to prepare HTTP request.</param>
        /// <param name="callerName">The caller name.</param>
        /// <returns>The <see cref="Task"/> containing the API response with the response model.</returns>
        protected async virtual Task<ApiResponse> CallAsync(RequestContext context, [CallerMemberName] string callerName = "")
        {
            var response = await InternalCallAsync(context, callerName);
            return response.ToApiResponse();
        }

        /// <summary>
        /// Executes the HTTP request asynchronously.
        /// </summary>
        /// <param name="context">The request context to prepare HTTP request.</param>
        /// <param name="callerName">The caller name.</param>
        /// <returns>The <see cref="Task"/> containing the REST response.</returns>
        protected async virtual Task<IRestResponse> InternalCallAsync(RequestContext context, [CallerMemberName] string callerName = "")
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var authenticationType = Configuration.GetAuthenticationType();
            _restClient.Authenticator = authenticationType != null
                ? AuthenticatorFactory?.Invoke(authenticationType, Configuration)
                : null;

            var request = PrepareRequest(context);

            _restClient.Timeout = Configuration.Timeout;
            _restClient.UserAgent = Configuration.UserAgent;

            var response = await _restClient.ExecuteAsync(request);
                       
            var exception = ExceptionFactory?.Invoke(callerName, response);
            if (exception != null)
                throw exception;

            return response;
        }
            
        #endregion

        #region Utilities

        private RestRequest PrepareRequest(RequestContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            
            var request = new RestRequest(context.Path, context.Method);

            // add path parameter, if any
            foreach(var param in context.PathParameters)
                request.AddParameter(param.Key, param.Value, ParameterType.UrlSegment);

            // add header parameter, if any
            foreach(var param in context.Headers)
                request.AddHeader(param.Key, param.Value);

            // add query parameter, if any
            foreach(var param in context.Query)
                request.AddQueryParameter(param.Key, param.Value);

            // add form parameter, if any
            foreach(var param in context.Form)
                request.AddParameter(param.Key, param.Value);

            // add file parameter, if any
            foreach(var param in context.Files)
                request.AddFile(param.Value.Name, param.Value.Writer, param.Value.FileName, param.Value.ContentLength, param.Value.ContentType);

            if (context.Body != null)
            {
                var bodyType = context.Body.GetType();
                if (bodyType == typeof(string))
                    request.AddParameter(ContentType.Json, context.Body, ParameterType.RequestBody);
                else if (bodyType == typeof(byte[]))
                    request.AddParameter(context.ContentType, context.Body, ParameterType.RequestBody);
            }

            return request;
        }
            
        #endregion
    }
}