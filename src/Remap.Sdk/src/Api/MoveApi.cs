using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the move endpoint.
    /// </summary>
    public class MoveApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="MoveApi" /> class
        /// with MoySklad credentials if specified and the HTTP client if specified (or use default).
        /// </summary>
        /// <param name="credentials">The MoySklad credentials.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public MoveApi(MoySkladCredentials credentials = null, HttpClient httpClient = null)
            : base("/api/remap/1.2/entity/move", credentials, httpClient)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the move.
        /// </summary>
        /// <param name="request">The move request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Move"/>.</returns>
        public virtual Task<ApiResponse<Move>> GetAsync(GetMoveRequest request) => GetByIdAsync<Move>(request.Id, request.Query);

        #endregion
    }
}
