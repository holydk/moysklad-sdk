namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an accumulation discount level.
    /// </summary>
    public class AccumulationDiscountLevel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        /// <value>The discount.</value>
        public int? Discount { get; set; }
            
        #endregion
    }
}