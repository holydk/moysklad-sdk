namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an report profit by employee.
    /// </summary>
    public class ReportProfitByEmployee : ReportProfit
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Employee information.
        /// </summary>
        /// <value>The Employee information.</value>
        public Employee Employee { get; set; }

        #endregion Properties
    }
}