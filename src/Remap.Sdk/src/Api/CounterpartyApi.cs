using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the counterparty endpoint.
    /// </summary>
    public class CounterpartyApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="CounterpartyApi" /> class
        /// with MoySklad credentials factory if specified and the HTTP client factory if specified (or use default).
        /// </summary>
        /// <param name="credentialsFactory">The factory to create the MoySklad credentials.</param>
        /// <param name="httpClientFactory">The factory to create the HTTP client.</param>
        public CounterpartyApi(Func<MoySkladCredentials> credentialsFactory = null, Func<HttpClient> httpClientFactory = null)
            : base("/api/remap/1.2/entity/counterparty", credentialsFactory, httpClientFactory)
        {
        }
            
        #endregion

        #region Methods

        /// <summary>
        /// Gets the counterparties.
        /// </summary>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="EntitiesResponse{Counterparty}"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<Counterparty>>> GetAllAsync(ApiParameterBuilder<CounterpartiesQuery> query = null) => GetAsync<EntitiesResponse<Counterparty>>(query);

        /// <summary>
        /// Gets the counterparty.
        /// </summary>
        /// <param name="id">The id to get the entity.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Counterparty"/>.</returns>
        public virtual Task<ApiResponse<Counterparty>> GetAsync(Guid id) => GetByIdAsync<Counterparty>(id);

        /// <summary>
        /// Creates the counterparty.
        /// </summary>
        /// <param name="counterparty">The counterparty.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Counterparty"/>.</returns>
        public virtual Task<ApiResponse<Counterparty>> CreateAsync(Counterparty counterparty) => CreateAsync<Counterparty>(counterparty);

        /// <summary>
        /// Updates the counterparty.
        /// </summary>
        /// <param name="counterparty">The counterparty.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Counterparty"/>.</returns>
        public virtual Task<ApiResponse<Counterparty>> UpdateAsync(Counterparty counterparty) => UpdateAsync<Counterparty>(counterparty);

        #endregion
    }
}