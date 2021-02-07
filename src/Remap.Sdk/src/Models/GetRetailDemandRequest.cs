using System;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents a request to get <see cref="RetailDemand"/>.
    /// </summary>
    public class GetRetailDemandRequest
    {
        #region Properties

        /// <summary>
        /// Gets or sets the retail demand id.
        /// </summary>
        /// <value>The retail demand id.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the API parameter builder to prepare the request query.
        /// </summary>
        /// <returns>The API parameter builder.</returns>
        public ApiParameterBuilder<RetailDemandQuery> Query { get; set; } = new ApiParameterBuilder<RetailDemandQuery>();

        #endregion
    }
}