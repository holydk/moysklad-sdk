using System;
using RestSharp;
using RestSharp.Serialization;

namespace Confetti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents a base API Accessor to interact with the API endpoint.
    /// </summary>
    public abstract class ApiAccessorBase : IApiAccessor
    {
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
        public virtual ExceptionFactory ExceptionFactory { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of authenticator.
        /// </summary>
        public virtual AuthenticatorFactory AuthenticatorFactory { get; set; }
            
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
        /// <param name="authenticationType">The authentication type.</param>
        /// <returns>The request context.</returns>
        protected virtual RequestContext PrepareRequestContext(Method method, string authenticationType = null)
        {
            var request = new RequestContext(Path, method);

            // prepare content type
            var contentTypes = new string[] {
                ContentType.Json
            };
            request.ContentType = ApiClient.SelectHeaderContentType(contentTypes);

            // prepare header accepts
            var headerAccepts = new string[] {
                "*/*"
            };
            request.AddHeader("Accept", ApiClient.SelectHeaderAccept(headerAccepts));

            // prepare default headers
            foreach (var header in Configuration.DefaultHeaders)
                request.AddHeader(header.Key, header.Value);

            // add authenticator
            if (!string.IsNullOrWhiteSpace(authenticationType))
                Configuration.ApiClient.RestClient.Authenticator = AuthenticatorFactory?.Invoke(authenticationType, Configuration);
            
            return request;
        }

        /// <summary>
        /// Deserializes the JSON string into a proper object.
        /// </summary>
        /// <param name="response">The REST response.</param>
        /// <typeparam name="T">The model type.</typeparam>
        /// <returns>The parsed model.</returns>
        protected virtual T Deserialize<T>(IRestResponse response)
        {
            return (T)Configuration.ApiClient.Deserialize(response, typeof(T));
        }
            
        #endregion
    }
}