using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the organization endpoint.
    /// </summary>
    public class OrganizationApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="OrganizationApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public OrganizationApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/organization", httpClient, credentials)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the organizations.
        /// </summary>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="EntitiesResponse{Organization}"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<Organization>>> GetAllAsync(ApiParameterBuilder query = null) => GetAsync<EntitiesResponse<Organization>>();

        #endregion
    }
}
