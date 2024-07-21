using Confiti.MoySklad.Remap.Client;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents a price query.
    /// </summary>
    public class PriceQuery
    {
        #region Properties

        /// <summary>
        /// Gets or sets the currency query.
        /// Note: 'expand' is allowed.
        /// </summary>
        /// <value>The currency query.</value>
        [AllowExpand]
        [Parameter("currency")]
        public CurrencyQuery Currency { get; set; }

        #endregion Properties
    }
}