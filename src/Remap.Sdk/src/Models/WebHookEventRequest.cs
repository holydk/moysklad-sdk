using Confiti.MoySklad.Remap.Entities;
using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents a response containing <see cref="WebHookEvent"/>'s.
    /// </summary>
    public class WebHookEventsResponse
    {
        #region Properties

        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        /// <value>The events.</value>
        [JsonProperty("events")]
        public WebHookEvent[] Events { get; set; }
            
        #endregion
    }
}