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
            
        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="DemandApi" /> class
        /// with MoySklad credentials factory if specified and the HTTP client factory if specified (or use default).
        /// </summary>
        /// <param name="credentialsFactory">The factory to create the MoySklad credentials.</param>
        /// <param name="httpClientFactory">The factory to create the HTTP client.</param>
        public DemandApi(Func<MoySkladCredentials> credentialsFactory = null, Func<HttpClient> httpClientFactory = null)
            : base("/api/remap/1.2/entity/demand", credentialsFactory, httpClientFactory)
        {
            Metadata = new MetadataApi<DocumentMetadata, DocumentMetadataQuery>(Path, credentialsFactory, httpClientFactory);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the demand.
        /// </summary>
        /// <param name="id">The id to get the entity.</param>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Demand"/>.</returns>
        public virtual Task<ApiResponse<Demand>> GetAsync(Guid id, ApiParameterBuilder<DemandQuery> query = null) => GetByIdAsync<Demand>(id, query);

        /// <summary>
        /// Creates the demand.
        /// </summary>
        /// <param name="demand">The demand.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Demand"/>.</returns>
        public virtual Task<ApiResponse<Demand>> CreateAsync(Demand demand) => CreateAsync<Demand>(demand);

        /// <summary>
        /// Updates the demand.
        /// </summary>
        /// <param name="demand">The demand.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Demand"/>.</returns>
        public virtual Task<ApiResponse<Demand>> UpdateAsync(Demand demand) => UpdateAsync<Demand>(demand);

        /// <summary>
        /// Deletes the demand.
        /// </summary>
        /// <param name="id">The demand ID.</param>
        /// <returns>The <see cref="Task"/> containing the API response.</returns>
        public virtual Task<ApiResponse> DeleteAsync(Guid id) => DeleteByIdAsync(id);

        #endregion
    }
}
