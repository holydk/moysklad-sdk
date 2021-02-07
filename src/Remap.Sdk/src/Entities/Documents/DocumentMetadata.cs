using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an document metadata.
    /// </summary>
    public class DocumentMetadata : MetaEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the attributes.
        /// </summary>
        /// <value>The attributes.</value>
        [JsonProperty("attributes")]
        public PagedMetaEntities<AttributeDefinition> Attributes { get; set; }

        /// <summary>
        /// Gets or sets the states.
        /// </summary>
        /// <value>The states.</value>
        [JsonProperty("states")]
        public State[] States { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the documents should be created as shared.
        /// </summary>
        /// <value>The value indicating whether to the documents should be created as shared.</value>
        [JsonProperty("createShared")]
        public bool? CreateShared { get; set; }

        #endregion
    }
}
