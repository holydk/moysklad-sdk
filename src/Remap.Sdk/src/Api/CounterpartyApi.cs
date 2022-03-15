using System.Net.Http;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;

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
        /// with MoySklad credentials if specified and the HTTP client if specified (or use default).
        /// </summary>
        /// <param name="credentials">The MoySklad credentials.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public CounterpartyApi(MoySkladCredentials credentials = null, HttpClient httpClient = null)
            : base("/api/remap/1.2/entity/counterparty", credentials, httpClient)
        {
        }
            
        #endregion

        #region Methods

        /// <summary>
        /// Gets the counterparties.
        /// </summary>
        /// <param name="request">The counterparties request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="GetCounterpartiesResponse"/>.</returns>
        public virtual Task<ApiResponse<GetCounterpartiesResponse>> GetAllAsync(GetCounterpartiesRequest request) => GetAsync<GetCounterpartiesResponse>(request.Query);

        /// <summary>
        /// Gets the counterparty.
        /// </summary>
        /// <param name="request">The counterparty request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Counterparty"/>.</returns>
        public virtual Task<ApiResponse<Counterparty>> GetAsync(GetCounterpartyRequest request) => GetByIdAsync<Counterparty>(request.Id, request.Query);

        /// <summary>
        /// Creates the counterparty.
        /// </summary>
        /// <param name="counterparty">The counterparty.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Counterparty"/>.</returns>
        public virtual Task<ApiResponse<Counterparty>> CreateAsync(Counterparty counterparty) => CreateAsync(counterparty);

        /// <summary>
        /// Updates the counterparty.
        /// </summary>
        /// <param name="counterparty">The counterparty.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Counterparty"/>.</returns>
        public virtual Task<ApiResponse<Counterparty>> UpdateAsync(Counterparty counterparty) => UpdateAsync(counterparty);

        #endregion
    }
}