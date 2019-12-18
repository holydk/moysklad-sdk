using Newtonsoft.Json;

namespace Confetti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents a response containing the access token.
    /// </summary>
    public class ObtainTokenResponse
    {
        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        /// <value>The access token.</value>
        [JsonProperty("access_token", Required = Required.Always)]
        public string AccessToken { get; set; }
    }
}