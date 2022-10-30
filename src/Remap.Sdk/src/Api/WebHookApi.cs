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
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public WebHookApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/webhook", httpClient, credentials)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Creates the web hook.
        /// </summary>
        /// <param name="webHook">The web hook.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="WebHook"/>.</returns>
        public virtual Task<ApiResponse<WebHook>> CreateAsync(WebHook webHook) => CreateAsync<WebHook>(webHook);

        /// <summary>
        /// Deletes the web hook.
        /// </summary>
        /// <param name="webHook">The web hook.</param>
        /// <returns>The <see cref="Task"/> containing the API response.</returns>
        public virtual Task<ApiResponse> DeleteAsync(WebHook webHook) => DeleteAsync<WebHook>(webHook);

        /// <summary>
        /// Gets the web hooks.
        /// </summary>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="EntitiesResponse{WebHook}"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<WebHook>>> GetAllAsync() => GetAsync<EntitiesResponse<WebHook>>();

        /// <summary>
        /// Gets the web hook by id.
        /// </summary>
        /// <param name="id">The web id.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="WebHook"/>.</returns>
        public virtual Task<ApiResponse<WebHook>> GetAsync(Guid id) => GetByIdAsync<WebHook>(id);

        /// <summary>
        /// Updates the web hook.
        /// </summary>
        /// <param name="webHook">The web hook.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="WebHook"/>.</returns>
        public virtual Task<ApiResponse<WebHook>> UpdateAsync(WebHook webHook) => UpdateAsync<WebHook>(webHook);

        #endregion Methods
    }
}