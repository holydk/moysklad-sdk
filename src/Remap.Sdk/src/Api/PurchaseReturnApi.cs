using System;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the purchase return endpoint.
    /// </summary>
    public class PurchaseReturnApi : ApiAccessorBase
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="PurchaseReturnApi" /> class
        /// with the API configuration is specified (or use <see cref="Configuration.Default" />) and base API path.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        /// <param name="basePath">The API base path.</param>
        public PurchaseReturnApi(Configuration configuration = null, string basePath = null)
            : base("/api/remap/1.2/entity/purchasereturn", basePath, configuration)
        {
        }
            
        #endregion

        #region Methods

        /// <summary>
        /// Gets the purchase return.
        /// </summary>
        /// <param name="request">The purchase return request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="PurchaseReturn"/>.</returns>
        public virtual Task<ApiResponse<PurchaseReturn>> GetAsync(GetPurchaseReturnRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var requestContext = PrepareRequestContext(path: $"{Path}/{request.Id}")
                .WithQuery(request.Query.Build());
            return CallAsync<PurchaseReturn>(requestContext);
        }

        #endregion
    }
}