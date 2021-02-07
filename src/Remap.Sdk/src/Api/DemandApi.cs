using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the demand endpoint.
    /// </summary>
    public class DemandApi : ApiAccessorBase
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="DemandApi" /> class
        /// with the base API path.
        /// </summary>
        /// <param name="basePath">The API base path.</param>
        public DemandApi(string basePath)
            : base(basePath, "/api/remap/1.2/entity/demand")
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="DemandApi" /> class
        /// with the API configuration.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        public DemandApi(Configuration configuration = null)
            : base("/api/remap/1.2/entity/demand", configuration)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the demand.
        /// </summary>
        /// <param name="request">The demand request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Demand"/>.</returns>
        public virtual Task<ApiResponse<Demand>> GetAsync(GetDemandRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var requestContext = PrepareRequestContext(path: $"{Path}/{request.Id}")
                .WithQuery(request.Query.Build());
            return CallAsync<Demand>(requestContext);
        }

        #endregion
    }
}
