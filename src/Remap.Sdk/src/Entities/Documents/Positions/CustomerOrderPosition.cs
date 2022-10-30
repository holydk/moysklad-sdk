namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an customer order position.
    /// </summary>
    public class CustomerOrderPosition : DocumentPosition
    {
        #region Properties

        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        /// <value>The discount.</value>
        public double? Discount { get; set; }

        /// <summary>
        /// Gets or sets the reserve.
        /// </summary>
        /// <value>The reserve.</value>
        public double? Reserve { get; set; }

        /// <summary>
        /// Gets or sets the shipped.
        /// </summary>
        /// <value>The shipped.</value>
        public double? Shipped { get; set; }

        /// <summary>
        /// Gets or sets the tax system.
        /// </summary>
        /// <value>The tax system.</value>
        public DocumentTaxSystem? TaxSystem { get; set; }

        /// <summary>
        /// Gets or sets the vat.
        /// </summary>
        /// <value>The vat.</value>
        public int? Vat { get; set; }

        #endregion Properties
    }
}