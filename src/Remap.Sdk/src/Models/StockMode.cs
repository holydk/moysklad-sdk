using Confiti.MoySklad.Remap.Client;

namespace Confiti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents a stock mode parameter for the assortment request.
    /// </summary>
    public enum StockMode
    {
        /// <summary>
        /// Uses to get the any balance in stock.
        /// </summary>
        [Parameter("all")]
        All,

        /// <summary>
        /// Uses to get the positive balance in stock.
        /// </summary>
        [Parameter("positiveOnly")]
        PositiveOnly,

        /// <summary>
        /// Uses to get the negative balance in stock.
        /// </summary>
        [Parameter("negativeOnly")]
        NegativeOnly,

        /// <summary>
        /// Uses to get the zero balance in stock.
        /// </summary>
        [Parameter("empty")]
        Empty,

        /// <summary>
        /// Uses to get the non-zero balance in stock.
        /// </summary>
        [Parameter("nonEmpty")]
        NonEmpty,

        /// <summary>
        /// Uses to get the under minimum balance in stock.
        /// </summary>
        [Parameter("underMinimum")]
        UnderMinimum
    }
}