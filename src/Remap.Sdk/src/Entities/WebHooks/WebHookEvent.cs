using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an web hook event.
    /// </summary>
    public class WebHookEvent : MetaEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the action of entity.
        /// </summary>
        /// <value>The action of entity.</value>
        [JsonProperty("action")]
        public EntityAction Action { get; set; }
            
        #endregion
    }
}