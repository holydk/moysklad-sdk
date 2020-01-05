using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Confetti.MoySklad.Remap.Extensions;
using RestSharp;
using RestSharp.Serialization;

namespace Confetti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents a base API Accessor to interact with the API endpoint.
    /// </summary>
    public abstract class ApiAccessorBase : IApiAccessor
    {
        #region Fields

        private ExceptionFactory _exceptionFactory;
        private AuthenticatorFactory _authenticatorFactory;
            
        #endregion

        #region Properties

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path.</value>
        public virtual string BasePath { get; }

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
        /// with the base API path and the API endpoint relative path.
        /// </summary>
        /// <param name="basePath">The API base path.</param>
        /// <param name="relativePath">The API endpoint relative path.</param>
        public ApiAccessorBase(string basePath, string relativePath)
            : this(relativePath, new Configuration(new ApiClient(basePath)))
        { }

        /// <summary>
        /// Creates a new instance of the <see cref="ApiClient" /> class
        /// with the API endpoint relative path and the API configuration.
        /// </summary>
        /// <param name="relativePath">The API endpoint relative path.</param>
        /// <param name="configuration">The API configuration.</param>
        public ApiAccessorBase(string relativePath, Configuration configuration = null)
        {
            if (configuration == null)
                Configuration = Configuration.Default;
            else
                Configuration = configuration;

            Path = relativePath ?? throw new ArgumentNullException(nameof(relativePath));
            BasePath = Configuration.ApiClient.RestClient.BaseUrl.ToString();
            ExceptionFactory = Configuration.DefaultExceptionFactory;
            AuthenticatorFactory = Configuration.DefaultAuthenticatorFactory;

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
                Configuration.ApiClient.Configuration = Configuration;
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
                .WithContentType(ApiClient.SelectHeaderContentType(new string[] { ContentType.Json }))
                .WithAccept(ApiClient.SelectHeaderAccept(new string[] { "*/*" }))
                .WithHeaders(Configuration.DefaultHeaders);
        }

        /// <summary>
        /// Uses selected authentication type for HTTP request (e.g. Basic, Bearer).
        /// If the authentication type is null then HTTP authentication header is not transmitted.
        /// </summary>
        /// <param name="authenticationType">The authentication type.</param>
        protected virtual void UseAuthentication(string authenticationType = null)
        {
            Configuration.ApiClient.RestClient.Authenticator = authenticationType != null 
                ? AuthenticatorFactory?.Invoke(authenticationType, Configuration)
                : null;
        }

        /// <summary>
        /// Deserializes the model into the JSON string.
        /// </summary>
        /// <param name="obj">The model.</param>
        /// <returns>The JSON string.</returns>
        protected virtual string Serialize(object obj)
        {
            return Configuration.ApiClient.Serialize(obj);
        }

        /// <summary>
        /// Deserializes the JSON string into a proper object.
        /// </summary>
        /// <param name="response">The REST response.</param>
        /// <typeparam name="T">The model type.</typeparam>
        /// <returns>The parsed model.</returns>
        protected virtual T Deserialize<T>(IRestResponse response)
        {
            if (response == null)
                throw new ArgumentNullException(nameof(response));

            return (T)Configuration.ApiClient.Deserialize(response, typeof(T));
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
            var response = await CallAsync(context, callerName);
            var model = Deserialize<TResponse>(response);

            return response.ToApiResponse(model);
        }

        /// <summary>
        /// Executes the HTTP request asynchronously.
        /// </summary>
        /// <param name="context">The request context to prepare HTTP request.</param>
        /// <param name="callerName">The caller name.</param>
        /// <returns>The <see cref="Task"/> containing the REST response.</returns>
        protected async virtual Task<IRestResponse> CallAsync(RequestContext context, [CallerMemberName] string callerName = "")
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var response = await Configuration.ApiClient.CallAsync(context);
                       
            var exception = ExceptionFactory?.Invoke(callerName, response);
            if (exception != null)
                throw exception;

            return response;
        }
            
        #endregion
    }
}