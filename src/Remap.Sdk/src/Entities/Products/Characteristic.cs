using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an characteristic of the variant.
    /// </summary>
    public class Characteristic : MetaEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the characteristic is required.
        /// </summary>
        /// <value>The value indicating whether to the characteristic is required.</value>
        [JsonProperty("required")]
        public bool? Required { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [JsonProperty("value")]
        public string Value { get; set; }
            
        #endregion
    }
}