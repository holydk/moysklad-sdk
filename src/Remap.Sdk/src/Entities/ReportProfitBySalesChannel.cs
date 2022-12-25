namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an report profit by sales channel.
    /// </summary>
    public sealed class ReportProfitBySalesChannel : ReportProfit
    {
        #region Properties
        /// <summary>
        /// Gets or sets the sales channel information.
        /// </summary>
        /// <value>The sales channel information.</value>
        public SalesChannel SalesChannel { get; set; }
        #endregion Properties
    }
}