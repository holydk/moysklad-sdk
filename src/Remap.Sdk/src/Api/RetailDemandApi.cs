using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the retail demand endpoint.
    /// </summary>
    public class RetailDemandApi : ApiAccessorBase
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="RetailDemandApi" /> class
        /// with the API configuration is specified (or use <see cref="Configuration.Default" />) and base API path.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        /// <param name="basePath">The API base path.</param>
        public RetailDemandApi(Configuration configuration = null, string basePath = null)
            : base("/api/remap/1.2/entity/retaildemand", basePath, configuration)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the retail demand.
        /// </summary>
        /// <param name="request">The retail demand request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="RetailDemand"/>.</returns>
        public virtual Task<ApiResponse<RetailDemand>> GetAsync(GetRetailDemandRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var requestContext = PrepareRequestContext(path: $"{Path}/{request.Id}")
                .WithQuery(request.Query.Build());
            return CallAsync<RetailDemand>(requestContext);
        }

        #endregion
    }
}
