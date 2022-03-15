using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the enter endpoint.
    /// </summary>
    public class EnterApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="EnterApi" /> class
        /// with MoySklad credentials if specified and the HTTP client if specified (or use default).
        /// </summary>
        /// <param name="credentials">The MoySklad credentials.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public EnterApi(MoySkladCredentials credentials = null, HttpClient httpClient = null)
            : base("/api/remap/1.2/entity/enter", credentials, httpClient)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the enter.
        /// </summary>
        /// <param name="request">The enter request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Enter"/>.</returns>
        public virtual Task<ApiResponse<Enter>> GetAsync(GetEnterRequest request) => GetByIdAsync<Enter>(request.Id, request.Query);

        #endregion
    }
}
