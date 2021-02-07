using System;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents a request to get <see cref="SalesReturn"/>.
    /// </summary>
    public class GetSalesReturnRequest
    {
        #region Properties

        /// <summary>
        /// Gets or sets the sales return id.
        /// </summary>
        /// <value>The sales return id.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the API parameter builder to prepare the request query.
        /// </summary>
        /// <returns>The API parameter builder.</returns>
        public ApiParameterBuilder<SalesReturnQuery> Query { get; set; } = new ApiParameterBuilder<SalesReturnQuery>();

        #endregion
    }
}