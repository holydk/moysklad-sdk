using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the product endpoint.
    /// </summary>
    public class ProductApi : ApiAccessor
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
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public ProductApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/product", httpClient, credentials)
        {
            Metadata = new MetadataApi<ProductMetadata, ProductMetadataQuery>(Path, httpClient, credentials);
            Images = new ImageApi(Path, httpClient, credentials);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the product by id.
        /// </summary>
        /// <param name="id">The id to get the entity.</param>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Product"/>.</returns>
        public virtual Task<ApiResponse<Product>> GetAsync(Guid id, ApiParameterBuilder<ProductQuery> query = null) => GetByIdAsync<Product>(id, query);

        #endregion
    }
}