using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the product endpoint.
    /// </summary>
    public class ProductApi : ApiAccessorBase
    {
        #region Properties

        /// <summary>
        /// Gets the API to interact with the metadata endpoint. 
        /// </summary>
        public virtual MetadataApi<ProductMetadata, ProductMetadataQuery> Metadata { get; }

        /// <summary>
        /// Gets the API to interact with the image endpoint. 
        /// </summary>
        public virtual ImageApi Images { get; }

        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ProductApi" /> class
        /// with the base API path.
        /// </summary>
        /// <param name="basePath">The API base path.</param>
        public ProductApi(string basePath)
            : base(basePath, "/api/remap/1.2/entity/product")
        {
            Metadata = new MetadataApi<ProductMetadata, ProductMetadataQuery>(basePath, Path);
            Images = new ImageApi(basePath, Path);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ProductApi" /> class
        /// with the API configuration.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        public ProductApi(Configuration configuration = null)
            : base("/api/remap/1.2/entity/product", configuration)
        {
            Metadata = new MetadataApi<ProductMetadata, ProductMetadataQuery>(Path, configuration);
            Images = new ImageApi(Path, configuration);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the product by id.
        /// </summary>
        /// <param name="request">The product request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Product"/>.</returns>
        public virtual Task<ApiResponse<Product>> GetAsync(GetProductRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var requestContext = PrepareRequestContext(path: $"{Path}/{request.Id}")
                .WithQuery(request.Query.Build());
            return CallAsync<Product>(requestContext);
        }

        #endregion
    }
}