using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Models;
using System;
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
        /// with MoySklad credentials factory if specified and the HTTP client factory if specified (or use default).
        /// </summary>
        /// <param name="credentialsFactory">The factory to create the MoySklad credentials.</param>
        /// <param name="httpClientFactory">The factory to create the HTTP client.</param>
        public ServiceApi(Func<MoySkladCredentials> credentialsFactory = null, Func<HttpClient> httpClientFactory = null)
            : base("/api/remap/1.2/entity/service", credentialsFactory, httpClientFactory)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <param name="request">The services request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="GetServicesResponse"/>.</returns>
        public virtual Task<ApiResponse<GetServicesResponse>> GetAllAsync(GetServicesRequest request) => GetAsync<GetServicesResponse>(request.Query);

        #endregion
    }
}
