using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the sales return endpoint.
    /// </summary>
    public class SalesReturnApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="SalesReturnApi" /> class
        /// with MoySklad credentials if specified and the HTTP client if specified (or use default).
        /// </summary>
        /// <param name="credentials">The MoySklad credentials.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public SalesReturnApi(MoySkladCredentials credentials = null, HttpClient httpClient = null)
            : base("/api/remap/1.2/entity/salesreturn", credentials, httpClient)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the sales return.
        /// </summary>
        /// <param name="request">The sales return request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="SalesReturn"/>.</returns>
        public virtual Task<ApiResponse<SalesReturn>> GetAsync(GetSalesReturnRequest request) => GetByIdAsync<SalesReturn>(request.Id, request.Query);

        #endregion
    }
}
