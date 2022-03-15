using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the variant endpoint.
    /// </summary>
    public class VariantApi : ApiAccessor
    {
        #region Properties

        /// <summary>
        /// Gets the API to interact with the metadata endpoint. 
        /// </summary>
        public virtual MetadataApi<VariantMetadata> Metadata { get; }

        /// <summary>
        /// Gets the API to interact with the image endpoint. 
        /// </summary>
        public virtual ImageApi Images { get; }

        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="VariantApi" /> class
        /// with MoySklad credentials if specified and the HTTP client if specified (or use default).
        /// </summary>
        /// <param name="credentials">The MoySklad credentials.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public VariantApi(MoySkladCredentials credentials = null, HttpClient httpClient = null)
            : base("/api/remap/1.2/entity/variant", credentials, httpClient)
        {
            Metadata = new MetadataApi<VariantMetadata>(Path, credentials, httpClient);
            Images = new ImageApi(Path, credentials, httpClient);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the variants.
        /// </summary>
        /// <param name="request">The variants request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="GetProductFoldersResponse"/>.</returns>
        public virtual Task<ApiResponse<GetVariantsResponse>> GetAllAsync(GetVariantsRequest request) => GetAsync<GetVariantsResponse>(request.Query);

        /// <summary>
        /// Gets the variant by id.
        /// </summary>
        /// <param name="request">The variant request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Variant"/>.</returns>
        public virtual Task<ApiResponse<Variant>> GetAsync(GetVariantRequest request) => GetByIdAsync<Variant>(request.Id, request.Query);

        /// <summary>
        /// Updates the variant.
        /// </summary>
        /// <param name="variant">The variant.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Variant"/>.</returns>
        public virtual Task<ApiResponse<Variant>> UpdateAsync(Variant variant) => UpdateAsync(variant);
            
        #endregion
    }
}