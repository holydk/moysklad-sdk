using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the move endpoint.
    /// </summary>
    public class MoveApi : ApiAccessorBase
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="MoveApi" /> class
        /// with the base API path.
        /// </summary>
        /// <param name="basePath">The API base path.</param>
        public MoveApi(string basePath)
            : base(basePath, "/api/remap/1.2/entity/move")
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="MoveApi" /> class
        /// with the API configuration.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        public MoveApi(Configuration configuration = null)
            : base("/api/remap/1.2/entity/move", configuration)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the move.
        /// </summary>
        /// <param name="request">The move request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Move"/>.</returns>
        public virtual Task<ApiResponse<Move>> GetAsync(GetMoveRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var requestContext = PrepareRequestContext(path: $"{Path}/{request.Id}")
                .WithQuery(request.Query.Build());
            return CallAsync<Move>(requestContext);
        }

        #endregion
    }
}
