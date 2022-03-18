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
        /// with MoySklad credentials if specified and the HTTP client if specified (or use default).
        /// </summary>
        /// <param name="credentials">The MoySklad credentials.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public DemandApi(MoySkladCredentials credentials = null, HttpClient httpClient = null)
            : base("/api/remap/1.2/entity/demand", credentials, httpClient)
        {
            Metadata = new MetadataApi<DocumentMetadata, DocumentMetadataQuery>(Path, credentials, httpClient);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the demand.
        /// </summary>
        /// <param name="request">The demand request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Demand"/>.</returns>
        public virtual Task<ApiResponse<Demand>> GetAsync(GetDemandRequest request) => GetByIdAsync<Demand>(request.Id, request.Query);

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
