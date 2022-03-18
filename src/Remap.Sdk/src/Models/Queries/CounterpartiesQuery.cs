using Confiti.MoySklad.Remap.Client;

namespace Confiti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents a counterparties query.
    /// </summary>
    public class CounterpartiesQuery
    {
        #region Properties

        /// <summary>
        /// Gets or sets the counterparty email.
        /// Note: 'filter', 'order' are allowed.
        /// </summary>
        /// <value>The counterparty email.</value>
        [Filter]
        [AllowOrder]
        [Parameter("email")]
        public string Email { get; set; }

        #endregion
    }
}