using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the sales channel endpoint.
    /// </summary>
    public class SalesChannelApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="SalesChannelApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public SalesChannelApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/saleschannel", httpClient, credentials)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Creates the sales channel.
        /// </summary>
        /// <param name="salesChannel">The sales channel.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="SalesChannel"/>.</returns>
        public virtual Task<ApiResponse<SalesChannel>> CreateAsync(SalesChannel salesChannel) => CreateAsync<SalesChannel>(salesChannel);

        /// <summary>
        /// Deletes the sales channel.
        /// </summary>
        /// <param name="salesChannel">The sales channel.</param>
        /// <returns>The <see cref="Task"/> containing the API response.</returns>
        public virtual Task<ApiResponse> DeleteAsync(SalesChannel salesChannel) => DeleteAsync<SalesChannel>(salesChannel);

        /// <summary>
        /// Deletes the sales channel by ID.
        /// </summary>
        /// <param name="id">The sales channel ID.</param>
        /// <returns>The <see cref="Task"/> containing the API response.</returns>
        public virtual Task<ApiResponse> DeleteAsync(Guid id) => DeleteByIdAsync(id);

        /// <summary>
        /// Gets the sales channels.
        /// </summary>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="EntitiesResponse{SalesChannel}"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<SalesChannel>>> GetAllAsync(ApiParameterBuilder query = null) => GetAsync<EntitiesResponse<SalesChannel>>(query);

        /// <summary>
        /// Gets the sales channel.
        /// </summary>
        /// <param name="id">The id to get the entity.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="SalesChannel"/>.</returns>
        public virtual Task<ApiResponse<SalesChannel>> GetAsync(Guid id) => GetByIdAsync<SalesChannel>(id);

        /// <summary>
        /// Updates the sales channel.
        /// </summary>
        /// <param name="salesChannel">The sales channel.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="SalesChannel"/>.</returns>
        public virtual Task<ApiResponse<SalesChannel>> UpdateAsync(SalesChannel salesChannel) => UpdateAsync<SalesChannel>(salesChannel);

        #endregion Methods
    }
}