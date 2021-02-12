using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the store endpoint.
    /// </summary>
    public class StoreApi : ApiAccessorBase
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="StoreApi" /> class
        /// with the API configuration is specified (or use <see cref="Configuration.Default" />) and base API path.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        /// <param name="basePath">The API base path.</param>
        public StoreApi(Configuration configuration = null, string basePath = null)
            : base("/api/remap/1.2/entity/store", basePath, configuration)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the stores.
        /// </summary>
        /// <param name="request">The stores request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="GetStoresResponse"/>.</returns>
        public virtual Task<ApiResponse<GetStoresResponse>> GetAllAsync(GetStoresRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var requestContext = PrepareRequestContext().WithQuery(request.Query.Build());
            return CallAsync<GetStoresResponse>(requestContext);
        }

        #endregion
    }
}
