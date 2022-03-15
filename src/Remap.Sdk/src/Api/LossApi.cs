using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the loss endpoint.
    /// </summary>
    public class LossApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="LossApi" /> class
        /// with MoySklad credentials if specified and the HTTP client if specified (or use default).
        /// </summary>
        /// <param name="credentials">The MoySklad credentials.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public LossApi(MoySkladCredentials credentials = null, HttpClient httpClient = null)
            : base("/api/remap/1.2/entity/loss", credentials, httpClient)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the loss.
        /// </summary>
        /// <param name="request">The loss request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Loss"/>.</returns>
        public virtual Task<ApiResponse<Loss>> GetAsync(GetLossRequest request) => GetByIdAsync<Loss>(request.Id, request.Query);

        #endregion
    }
}
