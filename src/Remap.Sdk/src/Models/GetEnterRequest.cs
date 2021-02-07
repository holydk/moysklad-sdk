using System;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents a request to get <see cref="Enter"/>.
    /// </summary>
    public class GetEnterRequest
    {
        #region Properties

        /// <summary>
        /// Gets or sets the enter id.
        /// </summary>
        /// <value>The enter id.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the API parameter builder to prepare the request query.
        /// </summary>
        /// <returns>The API parameter builder.</returns>
        public ApiParameterBuilder<EnterQuery> Query { get; set; } = new ApiParameterBuilder<EnterQuery>();

        #endregion
    }
}