namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an invoice position.
    /// </summary>
    public class InvoicePosition : DocumentPosition
    {
        #region Properties

        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        /// <value>The discount.</value>
        public double? Discount { get; set; }

        /// <summary>
        /// Gets or sets the vat.
        /// </summary>
        /// <value>The vat.</value>
        public int? Vat { get; set; }

        #endregion Properties
    }
}