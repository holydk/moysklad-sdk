using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
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
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public VariantApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/variant", httpClient, credentials)
        {
            Metadata = new MetadataApi<VariantMetadata>(Path, httpClient, credentials);
            Images = new ImageApi(Path, httpClient, credentials);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the variants.
        /// </summary>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="EntitiesResponse{Variant}"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<Variant>>> GetAllAsync(ApiParameterBuilder<VariantsQuery> query = null) => GetAsync<EntitiesResponse<Variant>>(query);

        /// <summary>
        /// Gets the variant by id.
        /// </summary>
        /// <param name="id">The id to get the entity.</param>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Variant"/>.</returns>
        public virtual Task<ApiResponse<Variant>> GetAsync(Guid id, ApiParameterBuilder<VariantQuery> query = null) => GetByIdAsync<Variant>(id, query);

        /// <summary>
        /// Updates the variant.
        /// </summary>
        /// <param name="variant">The variant.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Variant"/>.</returns>
        public virtual Task<ApiResponse<Variant>> UpdateAsync(Variant variant) => UpdateAsync<Variant>(variant);
            
        #endregion
    }
}