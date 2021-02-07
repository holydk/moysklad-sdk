using System;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents a request to get <see cref="Supply"/>.
    /// </summary>
    public class GetSupplyRequest
    {
        #region Properties

        /// <summary>
        /// Gets or sets the supply id.
        /// </summary>
        /// <value>The supply id.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the API parameter builder to prepare the request query.
        /// </summary>
        /// <returns>The API parameter builder.</returns>
        public ApiParameterBuilder<SupplyQuery> Query { get; set; } = new ApiParameterBuilder<SupplyQuery>();

        #endregion
    }
}