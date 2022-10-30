using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the loss endpoint.
    /// </summary>
    public class LossApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="LossApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public LossApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/loss", httpClient, credentials)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Gets the loss.
        /// </summary>
        /// <param name="id">The id to get the entity.</param>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Loss"/>.</returns>
        public virtual Task<ApiResponse<Loss>> GetAsync(Guid id, ApiParameterBuilder<LossQuery> query = null) => GetByIdAsync<Loss>(id, query);

        #endregion Methods
    }
}