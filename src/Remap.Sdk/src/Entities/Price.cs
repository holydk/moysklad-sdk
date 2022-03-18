namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an price.
    /// </summary>
    public class Price
    {
        #region Properties

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public decimal? Value { get; set; }

        /// <summary>
        /// Gets or sets the price type.
        /// </summary>
        /// <value>The price type.</value>
        public PriceType PriceType { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>The currency.</value>
        public Currency Currency { get; set; }
            
        #endregion
    }
}