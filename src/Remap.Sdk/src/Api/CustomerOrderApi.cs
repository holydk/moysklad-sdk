using System;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using RestSharp;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the customer order endpoint.
    /// </summary>
    public class CustomerOrderApi : ApiAccessorBase
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
        /// with the base API path.
        /// </summary>
        /// <param name="basePath">The API base path.</param>
        public CustomerOrderApi(string basePath)
            : base(basePath, "/api/remap/1.2/entity/customerorder")
        {
            Metadata = new MetadataApi<DocumentMetadata, DocumentMetadataQuery>(basePath, Path);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="CustomerOrderApi" /> class
        /// with the API configuration.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        public CustomerOrderApi(Configuration configuration = null)
            : base("/api/remap/1.2/entity/customerorder", configuration)
        {
            Metadata = new MetadataApi<DocumentMetadata, DocumentMetadataQuery>(Path, configuration);
        }
            
        #endregion

        #region Methods

        /// <summary>
        /// Gets the customer orders.
        /// </summary>
        /// <param name="request">The customer orders request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="GetCustomerOrdersResponse"/>.</returns>
        public virtual Task<ApiResponse<GetCustomerOrdersResponse>> GetAllAsync(GetCustomerOrdersRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            
            var requestContext = PrepareRequestContext().WithQuery(request.Query.Build());
            return CallAsync<GetCustomerOrdersResponse>(requestContext);
        }

        /// <summary>
        /// Gets the customer order.
        /// </summary>
        /// <param name="request">The customer order request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="CustomerOrder"/>.</returns>
        public virtual Task<ApiResponse<CustomerOrder>> GetAsync(GetCustomerOrderRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var requestContext = PrepareRequestContext(path: $"{Path}/{request.Id}")
                .WithQuery(request.Query.Build());
            return CallAsync<CustomerOrder>(requestContext);
        }

        /// <summary>
        /// Creates the customer order.
        /// </summary>
        /// <param name="order">The customer order.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="CustomerOrder"/>.</returns>
        public virtual Task<ApiResponse<CustomerOrder>> CreateAsync(CustomerOrder order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            var requestContext = PrepareRequestContext(method: Method.POST).WithBody(Serialize(order));
            return CallAsync<CustomerOrder>(requestContext);
        }

        /// <summary>
        /// Updates the customer order.
        /// </summary>
        /// <param name="customerOrder">The customer order.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="CustomerOrder"/>.</returns>
        public virtual Task<ApiResponse<CustomerOrder>> UpdateAsync(CustomerOrder customerOrder)
        {
            if (customerOrder == null)
                throw new ArgumentNullException(nameof(customerOrder));

            var requestContext = PrepareRequestContext(method: Method.PUT, path: $"{Path}/{customerOrder.Id}")
                .WithBody(Serialize(customerOrder));
            return CallAsync<CustomerOrder>(requestContext);
        }

        #endregion
    }
}