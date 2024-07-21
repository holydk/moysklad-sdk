using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents a <see cref="Variant"/> query.
    /// </summary>
    public class VariantQuery
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
        /// Gets or sets the product query.
        /// Note: 'expand' is allowed.
        /// </summary>
        /// <value>The product query.</value>
        [AllowExpand]
        [Parameter("product")]
        public ProductQuery Product { get; set; }

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