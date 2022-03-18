using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the purchase return endpoint.
    /// </summary>
    public class PurchaseReturnApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="PurchaseReturnApi" /> class
        /// with MoySklad credentials factory if specified and the HTTP client factory if specified (or use default).
        /// </summary>
        /// <param name="credentialsFactory">The factory to create the MoySklad credentials.</param>
        /// <param name="httpClientFactory">The factory to create the HTTP client.</param>
        public PurchaseReturnApi(Func<MoySkladCredentials> credentialsFactory = null, Func<HttpClient> httpClientFactory = null)
            : base("/api/remap/1.2/entity/purchasereturn", credentialsFactory, httpClientFactory)
        {
        }
            
        #endregion

        #region Methods

        /// <summary>
        /// Gets the purchase return.
        /// </summary>
        /// <param name="request">The purchase return request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="PurchaseReturn"/>.</returns>
        public virtual Task<ApiResponse<PurchaseReturn>> GetAsync(GetPurchaseReturnRequest request) => GetByIdAsync<PurchaseReturn>(request.Id, request.Query);

        #endregion
    }
}