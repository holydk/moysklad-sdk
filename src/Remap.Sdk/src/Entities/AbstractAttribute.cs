using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an abstract attribute.
    /// </summary>
    public abstract class AbstractAttribute : MetaEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the attribute type.
        /// </summary>
        /// <value>The attribute type.</value>
        [JsonProperty("type")]
        public AttributeType? Type { get; set; }
            
        #endregion
    }
}