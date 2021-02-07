using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Models;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the organization endpoint.
    /// </summary>
    public class OrganizationApi : ApiAccessorBase
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="OrganizationApi" /> class
        /// with the base API path.
        /// </summary>
        /// <param name="basePath">The API base path.</param>
        public OrganizationApi(string basePath)
            : base(basePath, "/api/remap/1.2/entity/organization")
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="OrganizationApi" /> class
        /// with the API configuration.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        public OrganizationApi(Configuration configuration = null)
            : base("/api/remap/1.2/entity/organization", configuration)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the organizations.
        /// </summary>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="GetProductFoldersResponse"/>.</returns>
        public virtual Task<ApiResponse<GetOrganizationsResponse>> GetAllAsync()
        {
            var requestContext = PrepareRequestContext();
            return CallAsync<GetOrganizationsResponse>(requestContext);
        }

        #endregion
    }
}
