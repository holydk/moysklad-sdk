namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an discount data.
    /// </summary>
    public class DiscountData
    {
        #region Properties

        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        /// <value>The discount.</value>
        public Discount Discount { get; set; }

        /// <summary>
        /// Gets or sets the personal discount.
        /// </summary>
        /// <value>The personal discount.</value>
        public double? PersonalDiscount { get; set; }

        /// <summary>
        /// Gets or sets the demand sum correction.
        /// </summary>
        /// <value>The demand sum correction.</value>
        public double? DemandSumCorrection { get; set; }
            
        #endregion
    }
}