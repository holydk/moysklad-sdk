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
        /// with MoySklad credentials factory if specified and the HTTP client factory if specified (or use default).
        /// </summary>
        /// <param name="credentialsFactory">The factory to create the MoySklad credentials.</param>
        /// <param name="httpClientFactory">The factory to create the HTTP client.</param>
        public VariantApi(Func<MoySkladCredentials> credentialsFactory = null, Func<HttpClient> httpClientFactory = null)
            : base("/api/remap/1.2/entity/variant", credentialsFactory, httpClientFactory)
        {
            Metadata = new MetadataApi<VariantMetadata>(Path, credentialsFactory, httpClientFactory);
            Images = new ImageApi(Path, credentialsFactory, httpClientFactory);
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