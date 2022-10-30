using Confiti.MoySklad.Remap.Client;

namespace Confiti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents a alcoholic query.
    /// </summary>
    public class AlcoholicQuery
    {
        #region Properties

        /// <summary>
        /// Gets or sets the code of the type product.
        /// </summary>
        /// <value>The code of the type product.</value>
        [Filter(overriddenOperators: new[] { "=", "!=" })]
        [Parameter("type")]
        public int? Type { get; set; }

        #endregion Properties
    }
}