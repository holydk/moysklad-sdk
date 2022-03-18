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
        /// with MoySklad credentials factory if specified and the HTTP client factory if specified (or use default).
        /// </summary>
        /// <param name="credentialsFactory">The factory to create the MoySklad credentials.</param>
        /// <param name="httpClientFactory">The factory to create the HTTP client.</param>
        public ProductApi(Func<MoySkladCredentials> credentialsFactory = null, Func<HttpClient> httpClientFactory = null)
            : base("/api/remap/1.2/entity/product", credentialsFactory, httpClientFactory)
        {
            Metadata = new MetadataApi<ProductMetadata, ProductMetadataQuery>(Path, credentialsFactory, httpClientFactory);
            Images = new ImageApi(Path, credentialsFactory, httpClientFactory);
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