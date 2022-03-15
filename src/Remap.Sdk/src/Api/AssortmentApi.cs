using System.Net.Http;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Models;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the assortment endpoint.
    /// </summary>
    public class AssortmentApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="AssortmentApi" /> class
        /// with MoySklad credentials if specified and the HTTP client if specified (or use default).
        /// </summary>
        /// <param name="credentials">The MoySklad credentials.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public AssortmentApi(MoySkladCredentials credentials = null, HttpClient httpClient = null)
            : base("/api/remap/1.2/entity/assortment", credentials, httpClient)
        {
        }
            
        #endregion

        #region Methods

        /// <summary>
        /// Gets the assortment.
        /// </summary>
        /// <param name="request">The assortment request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="GetAssortmentResponse"/>.</returns>
        public virtual Task<ApiResponse<GetAssortmentResponse>> GetAllAsync(GetAssortmentRequest request) => GetAsync<GetAssortmentResponse>(request.Query);
            
        #endregion
    }
}