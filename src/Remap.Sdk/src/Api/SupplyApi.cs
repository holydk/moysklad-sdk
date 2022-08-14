using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the supply endpoint.
    /// </summary>
    public class SupplyApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="SupplyApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public SupplyApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/supply", httpClient, credentials)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the supply.
        /// </summary>
        /// <param name="id">The id to get the entity.</param>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Supply"/>.</returns>
        public virtual Task<ApiResponse<Supply>> GetAsync(Guid id, ApiParameterBuilder<SupplyQuery> query = null) => GetByIdAsync<Supply>(id, query);

        #endregion
    }
}
