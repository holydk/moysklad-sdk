using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the service endpoint.
    /// </summary>
    public class ServiceApi : ApiAccessorBase
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ServiceApi" /> class
        /// with the base API path.
        /// </summary>
        /// <param name="basePath">The API base path.</param>
        public ServiceApi(string basePath)
            : base(basePath, "/api/remap/1.2/entity/service")
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ServiceApi" /> class
        /// with the API configuration.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        public ServiceApi(Configuration configuration = null)
            : base("/api/remap/1.2/entity/service", configuration)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <param name="request">The services request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="GetServicesResponse"/>.</returns>
        public virtual Task<ApiResponse<GetServicesResponse>> GetAllAsync(GetServicesRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var requestContext = PrepareRequestContext().WithQuery(request.Query.Build());
            return CallAsync<GetServicesResponse>(requestContext);
        }

        #endregion
    }
}
