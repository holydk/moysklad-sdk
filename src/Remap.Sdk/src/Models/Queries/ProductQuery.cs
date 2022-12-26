using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents a <see cref="Product"/> query.
    /// </summary>
    public class ProductQuery
    {
        #region Properties

        /// <summary>
        /// Gets or sets the buy price query.
        /// Note: 'expand' is allowed.
        /// </summary>
        /// <value>The buy price query.</value>
        [AllowExpand]
        [Parameter("buyPrice")]
        public PriceQuery BuyPrice { get; set; }

        /// <summary>
        /// Gets or sets the images.
        /// Note: 'expand' is allowed.
        /// </summary>
        /// <value>The images.</value>
        [AllowExpand]
        [Parameter("images")]
        public PagedEntities<Image> Images { get; set; }

        /// <summary>
        /// Gets or sets the sale prices query.
        /// Note: 'expand' is allowed.
        /// </summary>
        /// <value>The sale prices query.</value>
        [AllowExpand]
        [Parameter("salePrices")]
        public PriceQuery SalePrices { get; set; }

        #endregion Properties
    }
}