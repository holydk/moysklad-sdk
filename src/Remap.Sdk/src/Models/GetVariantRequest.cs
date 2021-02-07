using System;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents a request to get <see cref="Variant"/>.
    /// </summary>
    public class GetVariantRequest
    {
        #region Properties

        /// <summary>
        /// Gets or sets the variant id.
        /// </summary>
        /// <value>The variant id.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the API parameter builder to prepare the request query.
        /// </summary>
        /// <returns>The API parameter builder.</returns>
        public ApiParameterBuilder<VariantQuery> Query { get; set; } = new ApiParameterBuilder<VariantQuery>();

        #endregion
    }
}
