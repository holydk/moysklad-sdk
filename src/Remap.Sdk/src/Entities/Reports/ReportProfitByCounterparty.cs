namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an report profit by product.
    /// </summary>
    public class ReportProfitByCounterparty : ReportProfit
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Counterparty information.
        /// </summary>
        /// <value>The Counterparty information.</value>
        public Counterparty Counterparty { get; set; }

        #endregion Properties
    }
}