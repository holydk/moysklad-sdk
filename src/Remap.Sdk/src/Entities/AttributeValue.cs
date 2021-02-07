using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an attribute value.
    /// </summary>
    public class AttributeValue : AbstractAttribute
    {
        #region Properties

        /// <summary>
        /// Gets or sets the download meta.
        /// </summary>
        /// <value>The download meta.</value>
        [JsonProperty("download")]
        public Meta DownloadMeta { get; set; }

        /// <summary>
        /// Gets or sets the file.
        /// </summary>
        /// <value>The file.</value>
        [JsonProperty("file")]
        public File File { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [JsonProperty("value", NullValueHandling = NullValueHandling.Include)]
        public object Value { get; set; }
            
        #endregion
    }
}