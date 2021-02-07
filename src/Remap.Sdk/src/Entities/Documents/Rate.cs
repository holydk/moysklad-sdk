using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an rate.
    /// </summary>
    public class Rate
    {
        #region Properties

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>The currency.</value>
        [JsonProperty("currency")]
        public Currency Currency { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [JsonProperty("value")]
        public double? Value { get; set; }
            
        #endregion
    }
}