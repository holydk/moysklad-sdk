using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the sales return endpoint.
    /// </summary>
    public class SalesReturnApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="SalesReturnApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public SalesReturnApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/salesreturn", httpClient, credentials)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the sales returns.
        /// </summary>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="EntitiesResponse{SalesReturn}"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<SalesReturn>>> GetAllAsync(ApiParameterBuilder<SalesReturnQuery> query = null) => GetAsync<EntitiesResponse<SalesReturn>>(query);

        /// <summary>
        /// Gets the sales return.
        /// </summary>
        /// <param name="id">The id to get the entity.</param>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="SalesReturn"/>.</returns>
        public virtual Task<ApiResponse<SalesReturn>> GetAsync(Guid id, ApiParameterBuilder<SalesReturnQuery> query = null) => GetByIdAsync<SalesReturn>(id, query);

        /// <summary>
        /// Creates the sales return.
        /// </summary>
        /// <param name="salesReturn">The sales return.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="SalesReturn"/>.</returns>
        public virtual Task<ApiResponse<SalesReturn>> CreateAsync(SalesReturn salesReturn) => CreateAsync<SalesReturn>(salesReturn);

        /// <summary>
        /// Updates the sales return.
        /// </summary>
        /// <param name="salesReturn">The sales return.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="SalesReturn"/>.</returns>
        public virtual Task<ApiResponse<SalesReturn>> UpdateAsync(SalesReturn salesReturn) => UpdateAsync<SalesReturn>(salesReturn);

        /// <summary>
        /// Deletes the sales return.
        /// </summary>
        /// <param name="salesReturn">The sales return.</param>
        /// <returns>The <see cref="Task"/> containing the API response.</returns>
        public virtual Task<ApiResponse> DeleteAsync(SalesReturn salesReturn) => DeleteAsync<SalesReturn>(salesReturn);

        /// <summary>
        /// Deletes the sales return.
        /// </summary>
        /// <param name="id">The sales return id.</param>
        /// <returns>The <see cref="Task"/> containing the API response.</returns>
        public virtual Task<ApiResponse> DeleteAsync(Guid id) => DeleteByIdAsync(id);

        #endregion
    }
}
