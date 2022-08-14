using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the service endpoint.
    /// </summary>
    public class ServiceApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ServiceApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public ServiceApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/service", httpClient, credentials)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="EntitiesResponse{Service}"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<Service>>> GetAllAsync(ApiParameterBuilder query = null) => GetAsync<EntitiesResponse<Service>>(query);

        #endregion
    }
}
