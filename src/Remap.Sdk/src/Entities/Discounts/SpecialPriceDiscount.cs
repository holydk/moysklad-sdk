using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an special price discount.
    /// </summary>
    public class SpecialPriceDiscount : Discount
    {
        #region Properties

        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        /// <value>The discount.</value>
        [JsonProperty("discount")]
        public double? Discount { get; set; }

        /// <summary>
        /// Gets or sets the special price.
        /// </summary>
        /// <value>The special price.</value>
        [JsonProperty("specialPrice")]
        public Price SpecialPrice { get; set; }

        /// <summary>
        /// Gets or sets the product folders.
        /// </summary>
        /// <value>The product folders.</value>
        [JsonProperty("productFolders")]
        public ProductFolder[] ProductFolders { get; set; }
            
        #endregion
    }
}