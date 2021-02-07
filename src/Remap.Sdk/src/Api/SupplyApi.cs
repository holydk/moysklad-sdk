using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the supply endpoint.
    /// </summary>
    public class SupplyApi : ApiAccessorBase
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="SupplyApi" /> class
        /// with the base API path.
        /// </summary>
        /// <param name="basePath">The API base path.</param>
        public SupplyApi(string basePath)
            : base(basePath, "/api/remap/1.2/entity/supply")
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="SupplyApi" /> class
        /// with the API configuration.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        public SupplyApi(Configuration configuration = null)
            : base("/api/remap/1.2/entity/supply", configuration)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the supply.
        /// </summary>
        /// <param name="request">The supply request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Supply"/>.</returns>
        public virtual Task<ApiResponse<Supply>> GetAsync(GetSupplyRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var requestContext = PrepareRequestContext(path: $"{Path}/{request.Id}")
                .WithQuery(request.Query.Build());
            return CallAsync<Supply>(requestContext);
        }

        #endregion
    }
}
