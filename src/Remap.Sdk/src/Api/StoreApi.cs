using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the store endpoint.
    /// </summary>
    public class StoreApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="StoreApi" /> class
        /// with MoySklad credentials if specified and the HTTP client if specified (or use default).
        /// </summary>
        /// <param name="credentials">The MoySklad credentials.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public StoreApi(MoySkladCredentials credentials = null, HttpClient httpClient = null)
            : base("/api/remap/1.2/entity/store", credentials, httpClient)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the stores.
        /// </summary>
        /// <param name="request">The stores request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="GetStoresResponse"/>.</returns>
        public virtual Task<ApiResponse<GetStoresResponse>> GetAllAsync(GetStoresRequest request) => GetAsync<GetStoresResponse>(request.Query);

        #endregion
    }
}
