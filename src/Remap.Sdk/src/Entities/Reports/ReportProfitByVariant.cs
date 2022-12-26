namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an report profit by variant.
    /// </summary>
    public class ReportProfitByVariant : ReportProfit
    {
        #region Properties

        /// <summary>
        /// Gets or sets the assortment information.
        /// </summary>
        /// <value>The assortment information.</value>
        public Assortment Assortment { get; set; }

        #endregion Properties
    }
}