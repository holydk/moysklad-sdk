using Confiti.MoySklad.Remap.Client;
using System;
using System.Net.Http;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the bundle endpoint.
    /// </summary>
    public class BundleApi : ApiAccessor
    {
        #region Properties

        /// <summary>
        /// Gets the API to interact with the image endpoint. 
        /// </summary>
        public virtual ImageApi Images { get; }

        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="BundleApi" /> class
        /// with MoySklad credentials factory if specified and the HTTP client factory if specified (or use default).
        /// </summary>
        /// <param name="credentialsFactory">The factory to create the MoySklad credentials.</param>
        /// <param name="httpClientFactory">The factory to create the HTTP client.</param>
        public BundleApi(Func<MoySkladCredentials> credentialsFactory = null, Func<HttpClient> httpClientFactory = null)
            : base("/api/remap/1.2/entity/bundle", credentialsFactory, httpClientFactory)
        {
            Images = new ImageApi(Path, credentialsFactory, httpClientFactory);
        }
            
        #endregion
    }
}