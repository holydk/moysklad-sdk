namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an supply position.
    /// </summary>
    public class SupplyPosition : DocumentPosition
    {
        //private DocumentEntity.Gtd gtd;
        //private List<String> things;
        //private List<TrackingCode> trackingCodes;

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
        /// Gets or sets the overhead.
        /// </summary>
        /// <value>The overhead.</value>
        public long? Overhead { get; set; }

        /// <summary>
        /// Gets or sets the vat.
        /// </summary>
        /// <value>The vat.</value>
        public int? Vat { get; set; }

        #endregion Properties
    }
}