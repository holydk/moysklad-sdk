using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the loss endpoint.
    /// </summary>
    public class LossApi : ApiAccessorBase
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="LossApi" /> class
        /// with the base API path.
        /// </summary>
        /// <param name="basePath">The API base path.</param>
        public LossApi(string basePath)
            : base(basePath, "/api/remap/1.2/entity/loss")
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="LossApi" /> class
        /// with the API configuration.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        public LossApi(Configuration configuration = null)
            : base("/api/remap/1.2/entity/loss", configuration)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the loss.
        /// </summary>
        /// <param name="request">The loss request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Loss"/>.</returns>
        public virtual Task<ApiResponse<Loss>> GetAsync(GetLossRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var requestContext = PrepareRequestContext(path: $"{Path}/{request.Id}")
                .WithQuery(request.Query.Build());
            return CallAsync<Loss>(requestContext);
        }

        #endregion
    }
}
