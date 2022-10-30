namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an demand position.
    /// </summary>
    public class DemandPosition : DocumentPosition
    {
        // todo
        //private List<TrackingCode> trackingCodes;
        //private List<String> things;

        #region Properties

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