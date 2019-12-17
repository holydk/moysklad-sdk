using Newtonsoft.Json;

namespace Confetti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents the metadata about entity.
    /// </summary>
    public class Meta
    {
        #region Properties

        /// <summary>
        /// Gets or sets the entity reference.
        /// </summary>
        /// <value>The entity reference.</value>
        [JsonProperty("href", Required = Required.Always)]
        public string Href { get; set; }

        /// <summary>
        /// Gets or sets the entity metadata reference.
        /// </summary>
        /// <value>The entity metadata reference.</value>
        [JsonProperty("metadataHref", Required = Required.DisallowNull)]
        public string MetadataHref { get; set; }

        /// <summary>
        /// Gets or sets the type of entity.
        /// </summary>
        /// <value>The type of entity.</value>
        [JsonProperty("type", Required = Required.Always)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the media type.
        /// </summary>
        /// <value>The media type.</value>
        [JsonProperty("mediaType", Required = Required.Always)]
        public string MediaType { get; set; }

        /// <summary>
        /// Gets or sets the entity reference located in the UI.
        /// </summary>
        /// <value>The entity reference located on UI.</value>
        [JsonProperty("uuidHref", Required = Required.DisallowNull)]
        public string UuidHref { get; set; }

        /// <summary>
        /// Gets or sets the download reference.
        /// </summary>
        /// <value>The download reference.</value>
        [JsonProperty("downloadHref", Required = Required.DisallowNull)]
        public string DownloadHref { get; set; }
            
        #endregion
    }
}