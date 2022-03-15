using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the retail demand endpoint.
    /// </summary>
    public class RetailDemandApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="RetailDemandApi" /> class
        /// with MoySklad credentials if specified and the HTTP client if specified (or use default).
        /// </summary>
        /// <param name="credentials">The MoySklad credentials.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public RetailDemandApi(MoySkladCredentials credentials = null, HttpClient httpClient = null)
            : base("/api/remap/1.2/entity/retaildemand", credentials, httpClient)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the retail demand.
        /// </summary>
        /// <param name="request">The retail demand request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="RetailDemand"/>.</returns>
        public virtual Task<ApiResponse<RetailDemand>> GetAsync(GetRetailDemandRequest request) => GetByIdAsync<RetailDemand>(request.Id, request.Query);

        #endregion
    }
}
