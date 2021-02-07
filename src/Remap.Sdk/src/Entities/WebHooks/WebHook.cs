using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an web hook.
    /// </summary>
    public class WebHook : MetaEntity
    {
        /// <summary>
        /// Gets or sets the type of entity.
        /// </summary>
        /// <value>The type of entity.</value>
        [JsonProperty("entityType")]
        public EntityType EntityType { get; set; }

        /// <summary>
        /// Gets or sets the action of entity.
        /// </summary>
        /// <value>The action of entity.</value>
        [JsonProperty("action")]
        public EntityAction Action { get; set; }

        /// <summary>
        /// Gets or sets the method.
        /// </summary>
        /// <value>The method.</value>
        [JsonProperty("method")]
        public HttpMethod Method { get; set; }

        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        /// <value>The url.</value>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the web hook is enabled.
        /// </summary>
        /// <value>The value indicating whether to the web hook is enabled.</value>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }
}