using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an variant metadata.
    /// </summary>
    public class VariantMetadata : MetaEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the characteristics.
        /// </summary>
        /// <value>The characteristics.</value>
        [JsonProperty("characteristics")]
        public Characteristic[] Characteristics { get; set; }
            
        #endregion
    }
}