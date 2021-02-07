using System;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents a request to get <see cref="RetailSalesReturn"/>.
    /// </summary>
    public class GetRetailSalesReturnRequest
    {
        #region Properties

        /// <summary>
        /// Gets or sets the retail sales return id.
        /// </summary>
        /// <value>The retail sales return id.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the API parameter builder to prepare the request query.
        /// </summary>
        /// <returns>The API parameter builder.</returns>
        public ApiParameterBuilder<RetailSalesReturnQuery> Query { get; set; } = new ApiParameterBuilder<RetailSalesReturnQuery>();

        #endregion
    }
}