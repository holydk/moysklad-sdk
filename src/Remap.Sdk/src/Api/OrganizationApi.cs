using Confiti.MoySklad.Remap.Client;
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
        /// with MoySklad credentials if specified and the HTTP client if specified (or use default).
        /// </summary>
        /// <param name="credentials">The MoySklad credentials.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public OrganizationApi(MoySkladCredentials credentials = null, HttpClient httpClient = null)
            : base("/api/remap/1.2/entity/organization", credentials, httpClient)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the organizations.
        /// </summary>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="GetProductFoldersResponse"/>.</returns>
        public virtual Task<ApiResponse<GetOrganizationsResponse>> GetAllAsync() => GetAsync<GetOrganizationsResponse>();

        #endregion
    }
}
