using System;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using RestSharp;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the webhook endpoint.
    /// </summary>
    public class WebHookApi : ApiAccessorBase
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="WebHookApi" /> class
        /// with the API configuration is specified (or use <see cref="Configuration.Default" />) and base API path.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        /// <param name="basePath">The API base path.</param>
        public WebHookApi(Configuration configuration = null, string basePath = null)
            : base("/api/remap/1.2/entity/webhook", basePath, configuration)
        {
        }
            
        #endregion

        #region Methods

        /// <summary>
        /// Gets the web hooks.
        /// </summary>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="GetWebHooksResponse"/>.</returns>
        public virtual Task<ApiResponse<GetWebHooksResponse>> GetAllAsync()
        {
            var requestContext = PrepareRequestContext();
            return CallAsync<GetWebHooksResponse>(requestContext);
        }

        /// <summary>
        /// Gets the web hook by id.
        /// </summary>
        /// <param name="Id">The web id.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="WebHook"/>.</returns>
        public virtual Task<ApiResponse<WebHook>> GetAsync(Guid Id)
        {
            var requestContext = PrepareRequestContext(path: $"{Path}/{Id}");
            return CallAsync<WebHook>(requestContext);
        }

        /// <summary>
        /// Creates the web hook.
        /// </summary>
        /// <param name="webHook">The web hook.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="WebHook"/>.</returns>
        public virtual Task<ApiResponse<WebHook>> CreateAsync(WebHook webHook)
        {
            if (webHook == null)
                throw new ArgumentNullException(nameof(webHook));

            var requestContext = PrepareRequestContext(method: Method.POST)
                .WithBody(Serialize(webHook));
            return CallAsync<WebHook>(requestContext);
        }

        /// <summary>
        /// Updates the web hook.
        /// </summary>
        /// <param name="webHook">The web hook.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="WebHook"/>.</returns>
        public virtual Task<ApiResponse<WebHook>> UpdateAsync(WebHook webHook)
        {
            if (webHook == null)
                throw new ArgumentNullException(nameof(webHook));

            var requestContext = PrepareRequestContext(method: Method.PUT, path: $"{Path}/{webHook.Id}")
                .WithBody(Serialize(webHook));
            return CallAsync<WebHook>(requestContext);
        }

        /// <summary>
        /// Deletes the web hook.
        /// </summary>
        /// <param name="webHook">The web hook.</param>
        /// <returns>The <see cref="Task"/> containing the API response.</returns>
        public virtual Task<ApiResponse> DeleteAsync(WebHook webHook)
        {
            if (webHook == null)
                throw new ArgumentNullException(nameof(webHook));

            var requestContext = PrepareRequestContext(method: Method.DELETE, path: $"{Path}/{webHook.Id}")
                .WithBody(Serialize(webHook));
            return CallAsync(requestContext);
        }
            
        #endregion
    }
}