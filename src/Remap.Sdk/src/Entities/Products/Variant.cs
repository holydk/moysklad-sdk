using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an variant.
    /// </summary>
    public class Variant : AbstractProduct
    {
        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is archived.
        /// </summary>
        /// <value>The value indicating whether to the entity is archived.</value>
        [JsonProperty("archived")]
        public bool? Archived { get; set; }

        /// <summary>
        /// Gets or sets the minimum price.
        /// </summary>
        /// <value>The minimum price.</value>
        [JsonProperty("minPrice")]
        public Price MinPrice { get; set; }

        /// <summary>
        /// Gets or sets the sale prices.
        /// </summary>
        /// <value>The sale prices.</value>
        [JsonProperty("salePrices")]
        public Price[] SalePrices { get; set; }

        /// <summary>
        /// Gets or sets the characteristics.
        /// </summary>
        /// <value>The characteristics.</value>
        [JsonProperty("characteristics")]
        public Characteristic[] Characteristics { get; set; }

        /// <summary>
        /// Gets or sets the images.
        /// </summary>
        /// <value>The images.</value>
        [JsonProperty("images")]
        public PagedMetaEntities<Image> Images { get; set; }

        /// <summary>
        /// Gets or sets the buy price.
        /// </summary>
        /// <value>The buy price.</value>
        [JsonProperty("buyPrice")]
        public Price BuyPrice { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>The product.</value>
        [JsonProperty("product")]
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the serial numbers.
        /// </summary>
        /// <value>The serial numbers.</value>
        [JsonProperty("things")]
        public string[] Things { get; set; }
            
        #endregion
    }
}