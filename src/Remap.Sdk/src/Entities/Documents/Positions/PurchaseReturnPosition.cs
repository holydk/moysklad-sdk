namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an purchase return position.
    /// </summary>
    public class PurchaseReturnPosition : DocumentPosition
    {
        #region Properties

        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        /// <value>The discount.</value>
        public double? Discount { get; set; }

        /// <summary>
        /// Gets or sets the serial numbers.
        /// </summary>
        /// <value>The serial numbers.</value>
        public string[] Things { get; set; }

        /// <summary>
        /// Gets or sets the vat.
        /// </summary>
        /// <value>The vat.</value>
        public int? Vat { get; set; }

        #endregion Properties
    }
}