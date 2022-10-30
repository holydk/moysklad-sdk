using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the demand endpoint.
    /// </summary>
    public class DemandApi : ApiAccessor
    {
        #region Properties

        /// <summary>
        /// Gets the API to interact with the metadata endpoint.
        /// </summary>
        public virtual MetadataApi<DocumentMetadata, DocumentMetadataQuery> Metadata { get; }

        #endregion Properties

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="DemandApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public DemandApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/demand", httpClient, credentials)
        {
            Metadata = new MetadataApi<DocumentMetadata, DocumentMetadataQuery>(Path, httpClient, credentials);
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Creates the demand.
        /// </summary>
        /// <param name="demand">The demand.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Demand"/>.</returns>
        public virtual Task<ApiResponse<Demand>> CreateAsync(Demand demand) => CreateAsync<Demand>(demand);

        /// <summary>
        /// Deletes the demand.
        /// </summary>
        /// <param name="id">The demand ID.</param>
        /// <returns>The <see cref="Task"/> containing the API response.</returns>
        public virtual Task<ApiResponse> DeleteAsync(Guid id) => DeleteByIdAsync(id);

        /// <summary>
        /// Gets the demand.
        /// </summary>
        /// <param name="id">The id to get the entity.</param>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Demand"/>.</returns>
        public virtual Task<ApiResponse<Demand>> GetAsync(Guid id, ApiParameterBuilder<DemandQuery> query = null) => GetByIdAsync<Demand>(id, query);

        /// <summary>
        /// Updates the demand.
        /// </summary>
        /// <param name="demand">The demand.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Demand"/>.</returns>
        public virtual Task<ApiResponse<Demand>> UpdateAsync(Demand demand) => UpdateAsync<Demand>(demand);

        #endregion Methods
    }
}