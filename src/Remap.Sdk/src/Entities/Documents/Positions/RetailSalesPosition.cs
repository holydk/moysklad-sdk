namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an retail sales position.
    /// </summary>
    public class RetailSalesPosition : DocumentPosition
    {
        //private List<String> things;

        #region Properties

        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        /// <value>The cost.</value>
        public long? Cost { get; set; }

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