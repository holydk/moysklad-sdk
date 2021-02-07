using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the retail sales return endpoint.
    /// </summary>
    public class RetailSalesReturnApi : ApiAccessorBase
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="RetailSalesReturnApi" /> class
        /// with the base API path.
        /// </summary>
        /// <param name="basePath">The API base path.</param>
        public RetailSalesReturnApi(string basePath)
            : base(basePath, "/api/remap/1.2/entity/retailsalesreturn")
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="RetailSalesReturnApi" /> class
        /// with the API configuration.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        public RetailSalesReturnApi(Configuration configuration = null)
            : base("/api/remap/1.2/entity/retailsalesreturn", configuration)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the retail sales return.
        /// </summary>
        /// <param name="request">The retail sales return request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="RetailSalesReturn"/>.</returns>
        public virtual Task<ApiResponse<RetailSalesReturn>> GetAsync(GetRetailSalesReturnRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var requestContext = PrepareRequestContext(path: $"{Path}/{request.Id}")
                .WithQuery(request.Query.Build());
            return CallAsync<RetailSalesReturn>(requestContext);
        }

        #endregion
    }
}
