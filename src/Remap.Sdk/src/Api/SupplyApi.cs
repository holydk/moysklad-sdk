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
        /// with MoySklad credentials factory if specified and the HTTP client factory if specified (or use default).
        /// </summary>
        /// <param name="credentialsFactory">The factory to create the MoySklad credentials.</param>
        /// <param name="httpClientFactory">The factory to create the HTTP client.</param>
        public SupplyApi(Func<MoySkladCredentials> credentialsFactory = null, Func<HttpClient> httpClientFactory = null)
            : base("/api/remap/1.2/entity/supply", credentialsFactory, httpClientFactory)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the supply.
        /// </summary>
        /// <param name="request">The supply request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Supply"/>.</returns>
        public virtual Task<ApiResponse<Supply>> GetAsync(GetSupplyRequest request) => GetByIdAsync<Supply>(request.Id, request.Query);

        #endregion
    }
}
