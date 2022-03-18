using System.Net.Http;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;

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

        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="CustomerOrderApi" /> class
        /// with MoySklad credentials if specified and the HTTP client if specified (or use default).
        /// </summary>
        /// <param name="credentials">The MoySklad credentials.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public CustomerOrderApi(MoySkladCredentials credentials = null, HttpClient httpClient = null)
            : base("/api/remap/1.2/entity/customerorder", credentials, httpClient)
        {
            Metadata = new MetadataApi<DocumentMetadata, DocumentMetadataQuery>(Path, credentials, httpClient);
        }
            
        #endregion

        #region Methods

        /// <summary>
        /// Gets the customer orders.
        /// </summary>
        /// <param name="request">The customer orders request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="GetCustomerOrdersResponse"/>.</returns>
        public virtual Task<ApiResponse<GetCustomerOrdersResponse>> GetAllAsync(GetCustomerOrdersRequest request) => GetAsync<GetCustomerOrdersResponse>(request.Query);

        /// <summary>
        /// Gets the customer order.
        /// </summary>
        /// <param name="request">The customer order request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="CustomerOrder"/>.</returns>
        public virtual Task<ApiResponse<CustomerOrder>> GetAsync(GetCustomerOrderRequest request) => GetByIdAsync<CustomerOrder>(request.Id, request.Query);

        /// <summary>
        /// Creates the customer order.
        /// </summary>
        /// <param name="customerOrder">The customer order.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="CustomerOrder"/>.</returns>
        public virtual Task<ApiResponse<CustomerOrder>> CreateAsync(CustomerOrder customerOrder) => CreateAsync<CustomerOrder>(customerOrder);

        /// <summary>
        /// Updates the customer order.
        /// </summary>
        /// <param name="customerOrder">The customer order.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="CustomerOrder"/>.</returns>
        public virtual Task<ApiResponse<CustomerOrder>> UpdateAsync(CustomerOrder customerOrder) => UpdateAsync<CustomerOrder>(customerOrder);

        #endregion
    }
}