using System;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using RestSharp;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the counterparty endpoint.
    /// </summary>
    public class CounterpartyApi : ApiAccessorBase
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="CounterpartyApi" /> class
        /// with the API configuration is specified (or use <see cref="Configuration.Default" />) and base API path.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        /// <param name="basePath">The API base path.</param>
        public CounterpartyApi(Configuration configuration = null, string basePath = null)
            : base("/api/remap/1.2/entity/counterparty", basePath, configuration)
        {
        }
            
        #endregion

        #region Methods

        /// <summary>
        /// Gets the counterparties.
        /// </summary>
        /// <param name="request">The counterparties request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="GetCounterpartiesResponse"/>.</returns>
        public virtual Task<ApiResponse<GetCounterpartiesResponse>> GetAllAsync(GetCounterpartiesRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var requestContext = PrepareRequestContext().WithQuery(request.Query.Build());
            return CallAsync<GetCounterpartiesResponse>(requestContext);
        }

        /// <summary>
        /// Gets the counterparty.
        /// </summary>
        /// <param name="request">The counterparty request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Counterparty"/>.</returns>
        public virtual Task<ApiResponse<Counterparty>> GetAsync(GetCounterpartyRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var requestContext = PrepareRequestContext(path: $"{Path}/{request.Id}")
                .WithQuery(request.Query.Build());
            return CallAsync<Counterparty>(requestContext);
        }

        /// <summary>
        /// Creates the counterparty.
        /// </summary>
        /// <param name="counterparty">The counterparty.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Counterparty"/>.</returns>
        public virtual Task<ApiResponse<Counterparty>> CreateAsync(Counterparty counterparty)
        {
            if (counterparty == null)
                throw new ArgumentNullException(nameof(counterparty));

            var requestContext = PrepareRequestContext(method: Method.POST).WithBody(Serialize(counterparty));
            return CallAsync<Counterparty>(requestContext);
        }

        /// <summary>
        /// Updates the counterparty.
        /// </summary>
        /// <param name="counterparty">The counterparty.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Counterparty"/>.</returns>
        public virtual Task<ApiResponse<Counterparty>> UpdateAsync(Counterparty counterparty)
        {
            if (counterparty == null)
                throw new ArgumentNullException(nameof(counterparty));

            var requestContext = PrepareRequestContext(method: Method.PUT, path: $"{Path}/{counterparty.Id}")
                .WithBody(Serialize(counterparty));
            return CallAsync<Counterparty>(requestContext);
        }

        #endregion
    }
}