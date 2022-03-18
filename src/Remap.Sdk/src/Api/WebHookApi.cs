using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the webhook endpoint.
    /// </summary>
    public class WebHookApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="WebHookApi" /> class
        /// with MoySklad credentials factory if specified and the HTTP client factory if specified (or use default).
        /// </summary>
        /// <param name="credentialsFactory">The factory to create the MoySklad credentials.</param>
        /// <param name="httpClientFactory">The factory to create the HTTP client.</param>
        public WebHookApi(Func<MoySkladCredentials> credentialsFactory = null, Func<HttpClient> httpClientFactory = null)
            : base("/api/remap/1.2/entity/webhook", credentialsFactory, httpClientFactory)
        {
        }
            
        #endregion

        #region Methods

        /// <summary>
        /// Gets the web hooks.
        /// </summary>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="GetWebHooksResponse"/>.</returns>
        public virtual Task<ApiResponse<GetWebHooksResponse>> GetAllAsync() => GetAsync<GetWebHooksResponse>();

        /// <summary>
        /// Gets the web hook by id.
        /// </summary>
        /// <param name="id">The web id.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="WebHook"/>.</returns>
        public virtual Task<ApiResponse<WebHook>> GetAsync(Guid id) => GetByIdAsync<WebHook>(id);

        /// <summary>
        /// Creates the web hook.
        /// </summary>
        /// <param name="webHook">The web hook.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="WebHook"/>.</returns>
        public virtual Task<ApiResponse<WebHook>> CreateAsync(WebHook webHook) => CreateAsync<WebHook>(webHook);

        /// <summary>
        /// Updates the web hook.
        /// </summary>
        /// <param name="webHook">The web hook.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="WebHook"/>.</returns>
        public virtual Task<ApiResponse<WebHook>> UpdateAsync(WebHook webHook) => UpdateAsync<WebHook>(webHook);

        /// <summary>
        /// Deletes the web hook.
        /// </summary>
        /// <param name="webHook">The web hook.</param>
        /// <returns>The <see cref="Task"/> containing the API response.</returns>
        public virtual Task<ApiResponse> DeleteAsync(WebHook webHook) => DeleteAsync<WebHook>(webHook);
            
        #endregion
    }
}