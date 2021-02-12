using Confiti.MoySklad.Remap.Client;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the bundle endpoint.
    /// </summary>
    public class BundleApi : ApiAccessorBase
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
        /// with the API configuration is specified (or use <see cref="Configuration.Default" />) and base API path.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        /// <param name="basePath">The API base path.</param>
        public BundleApi(Configuration configuration = null, string basePath = null)
            : base("/api/remap/1.2/entity/bundle", basePath, configuration)
        {
        }
            
        #endregion
    }
}