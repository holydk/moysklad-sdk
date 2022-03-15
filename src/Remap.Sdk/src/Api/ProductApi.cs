using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
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
        /// with MoySklad credentials if specified and the HTTP client if specified (or use default).
        /// </summary>
        /// <param name="credentials">The MoySklad credentials.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public ProductApi(MoySkladCredentials credentials = null, HttpClient httpClient = null)
            : base("/api/remap/1.2/entity/product", credentials, httpClient)
        {
            Metadata = new MetadataApi<ProductMetadata, ProductMetadataQuery>(Path, credentials, httpClient);
            Images = new ImageApi(Path, credentials, httpClient);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the product by id.
        /// </summary>
        /// <param name="request">The product request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Product"/>.</returns>
        public virtual Task<ApiResponse<Product>> GetAsync(GetProductRequest request) => GetByIdAsync<Product>(request.Id, request.Query);

        #endregion
    }
}