using System;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents a request to get <see cref="Demand"/>.
    /// </summary>
    public class GetDemandRequest
    {
        #region Properties

        /// <summary>
        /// Gets or sets the demand id.
        /// </summary>
        /// <value>The demand id.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the API parameter builder to prepare the request query.
        /// </summary>
        /// <returns>The API parameter builder.</returns>
        public ApiParameterBuilder<DemandQuery> Query { get; set; } = new ApiParameterBuilder<DemandQuery>();

        #endregion
    }
}