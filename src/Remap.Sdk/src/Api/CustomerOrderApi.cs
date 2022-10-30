using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the customer order endpoint.
    /// </summary>
    public class CustomerOrderApi : ApiAccessor
    {
        #region Properties

        /// <summary>
        /// Gets the API to interact with the metadata endpoint.
        /// </summary>
        public virtual MetadataApi<DocumentMetadata, DocumentMetadataQuery> Metadata { get; }

        #endregion Properties

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="CustomerOrderApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public CustomerOrderApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/customerorder", httpClient, credentials)
        {
            Metadata = new MetadataApi<DocumentMetadata, DocumentMetadataQuery>(Path, httpClient, credentials);
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Creates the customer order.
        /// </summary>
        /// <param name="customerOrder">The customer order.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="CustomerOrder"/>.</returns>
        public virtual Task<ApiResponse<CustomerOrder>> CreateAsync(CustomerOrder customerOrder) => CreateAsync<CustomerOrder>(customerOrder);

        /// <summary>
        /// Gets the customer orders.
        /// </summary>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="EntitiesResponse{CustomerOrder}"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<CustomerOrder>>> GetAllAsync(ApiParameterBuilder<CustomerOrdersQuery> query = null) => GetAsync<EntitiesResponse<CustomerOrder>>(query);

        /// <summary>
        /// Gets the customer order.
        /// </summary>
        /// <param name="id">The id to get the entity.</param>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="CustomerOrder"/>.</returns>
        public virtual Task<ApiResponse<CustomerOrder>> GetAsync(Guid id, ApiParameterBuilder<CustomerOrderQuery> query = null) => GetByIdAsync<CustomerOrder>(id, query);

        /// <summary>
        /// Updates the customer order.
        /// </summary>
        /// <param name="customerOrder">The customer order.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="CustomerOrder"/>.</returns>
        public virtual Task<ApiResponse<CustomerOrder>> UpdateAsync(CustomerOrder customerOrder) => UpdateAsync<CustomerOrder>(customerOrder);

        #endregion Methods
    }
}