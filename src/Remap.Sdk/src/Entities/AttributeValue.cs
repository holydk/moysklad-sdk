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
        public Meta Download { get; set; }

        /// <summary>
        /// Gets or sets the file.
        /// </summary>
        /// <value>The file.</value>
        public File File { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public object Value { get; set; }
            
        #endregion
    }
}