using System;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents a request to get <see cref="Loss"/>.
    /// </summary>
    public class GetLossRequest
    {
        #region Properties

        /// <summary>
        /// Gets or sets the loss id.
        /// </summary>
        /// <value>The loss id.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the API parameter builder to prepare the request query.
        /// </summary>
        /// <returns>The API parameter builder.</returns>
        public ApiParameterBuilder<LossQuery> Query { get; set; } = new ApiParameterBuilder<LossQuery>();

        #endregion
    }
}