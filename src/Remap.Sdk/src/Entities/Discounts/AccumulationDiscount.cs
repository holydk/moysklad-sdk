using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an accumulation discount.
    /// </summary>
    public class AccumulationDiscount : Discount
    {
        #region Properties

        /// <summary>
        /// Gets or sets the product folders.
        /// </summary>
        /// <value>The product folders.</value>
        [JsonProperty("productFolders")]
        public ProductFolder[] ProductFolders { get; set; }

        /// <summary>
        /// Gets or sets the levels.
        /// </summary>
        /// <value>The levels.</value>
        [JsonProperty("levels")]
        public AccumulationDiscountLevel[] Levels { get; set; }
            
        #endregion
    }
}