using System;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents a <see cref="Variant"/>'s query.
    /// </summary>
    public class VariantsQuery : VariantQuery
    {
        #region Properties

        /// <summary>
        /// Gets or sets the product id.
        /// </summary>
        /// <value>The product id.</value>
        [Filter]
        [Parameter("productid")]
        public Guid ProductId { get; set; }

        #endregion Properties
    }
}