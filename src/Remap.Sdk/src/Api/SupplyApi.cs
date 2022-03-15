using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
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
        /// with MoySklad credentials if specified and the HTTP client if specified (or use default).
        /// </summary>
        /// <param name="credentials">The MoySklad credentials.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public SupplyApi(MoySkladCredentials credentials = null, HttpClient httpClient = null)
            : base("/api/remap/1.2/entity/supply", credentials, httpClient)
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
