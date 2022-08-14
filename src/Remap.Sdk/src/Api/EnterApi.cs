using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the enter endpoint.
    /// </summary>
    public class EnterApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="EnterApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public EnterApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/enter", httpClient, credentials)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the enter.
        /// </summary>
        /// <param name="id">The id to get the entity.</param>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Enter"/>.</returns>
        public virtual Task<ApiResponse<Enter>> GetAsync(Guid id, ApiParameterBuilder<EnterQuery> query = null) => GetByIdAsync<Enter>(id, query);

        #endregion
    }
}
