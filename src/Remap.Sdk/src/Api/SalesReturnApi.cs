using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the sales return endpoint.
    /// </summary>
    public class SalesReturnApi : ApiAccessorBase
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="SalesReturnApi" /> class
        /// with the base API path.
        /// </summary>
        /// <param name="basePath">The API base path.</param>
        public SalesReturnApi(string basePath)
            : base(basePath, "/api/remap/1.2/entity/salesreturn")
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="SalesReturnApi" /> class
        /// with the API configuration.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        public SalesReturnApi(Configuration configuration = null)
            : base("/api/remap/1.2/entity/salesreturn", configuration)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the sales return.
        /// </summary>
        /// <param name="request">The sales return request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="SalesReturn"/>.</returns>
        public virtual Task<ApiResponse<SalesReturn>> GetAsync(GetSalesReturnRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var requestContext = PrepareRequestContext(path: $"{Path}/{request.Id}")
                .WithQuery(request.Query.Build());
            return CallAsync<SalesReturn>(requestContext);
        }

        #endregion
    }
}
