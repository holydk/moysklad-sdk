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
        /// with the base API path.
        /// </summary>
        /// <param name="basePath">The API base path.</param>
        public BundleApi(string basePath)
            : base(basePath, "/api/remap/1.2/entity/bundle")
        {
            Images = new ImageApi(basePath, Path);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="BundleApi" /> class
        /// with the API configuration.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        public BundleApi(Configuration configuration = null)
            : base("/api/remap/1.2/entity/bundle", configuration)
        {
            Images = new ImageApi(Path, configuration);
        }
            
        #endregion
    }
}