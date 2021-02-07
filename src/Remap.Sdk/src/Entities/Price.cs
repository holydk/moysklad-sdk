using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an price.
    /// </summary>
    public class Price
    {
        #region Properties

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [JsonProperty("value")]
        public decimal? Value { get; set; }

        /// <summary>
        /// Gets or sets the price type.
        /// </summary>
        /// <value>The price type.</value>
        [JsonProperty("priceType")]
        public PriceType PriceType { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>The currency.</value>
        [JsonProperty("currency")]
        public Currency Currency { get; set; }
            
        #endregion
    }
}