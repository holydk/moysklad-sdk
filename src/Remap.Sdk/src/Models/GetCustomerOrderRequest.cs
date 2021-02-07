using System;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents a request to get <see cref="CustomerOrder"/>.
    /// </summary>
    public class GetCustomerOrderRequest
    {
        #region Properties

        /// <summary>
        /// Gets or sets the customer order id.
        /// </summary>
        /// <value>The customer order id.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the API parameter builder to prepare the request query.
        /// </summary>
        /// <returns>The API parameter builder.</returns>
        public ApiParameterBuilder<CustomerOrderQuery> Query { get; set; } = new ApiParameterBuilder<CustomerOrderQuery>();
            
        #endregion
    }
}