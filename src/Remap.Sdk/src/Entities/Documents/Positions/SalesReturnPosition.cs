namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an sales return position.
    /// </summary>
    public class SalesReturnPosition : DocumentPosition
    {
        // todo
        //private DocumentEntity.Gtd gtd;
        //private List<String> things;

        #region Properties

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        public Country Country { get; set; }

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

        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        /// <value>The cost.</value>
        public long? Cost { get; set; }

        #endregion
    }
}