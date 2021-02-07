using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the enter endpoint.
    /// </summary>
    public class EnterApi : ApiAccessorBase
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="EnterApi" /> class
        /// with the base API path.
        /// </summary>
        /// <param name="basePath">The API base path.</param>
        public EnterApi(string basePath)
            : base(basePath, "/api/remap/1.2/entity/enter")
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="EnterApi" /> class
        /// with the API configuration.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        public EnterApi(Configuration configuration = null)
            : base("/api/remap/1.2/entity/enter", configuration)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the enter.
        /// </summary>
        /// <param name="request">The enter request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Enter"/>.</returns>
        public virtual Task<ApiResponse<Enter>> GetAsync(GetEnterRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var requestContext = PrepareRequestContext(path: $"{Path}/{request.Id}")
                .WithQuery(request.Query.Build());
            return CallAsync<Enter>(requestContext);
        }

        #endregion
    }
}
