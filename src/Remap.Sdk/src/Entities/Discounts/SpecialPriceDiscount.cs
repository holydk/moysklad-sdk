namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an special price discount.
    /// </summary>
    public class SpecialPriceDiscount : GoodDiscount
    {
        #region Properties

        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        /// <value>The discount.</value>
        public double? Discount { get; set; }

        /// <summary>
        /// Gets or sets the special price.
        /// </summary>
        /// <value>The special price.</value>
        public Price SpecialPrice { get; set; }

        #endregion Properties
    }
}