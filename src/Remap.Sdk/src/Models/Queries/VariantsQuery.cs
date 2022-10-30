using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using System;

namespace Confiti.MoySklad.Remap.Models
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