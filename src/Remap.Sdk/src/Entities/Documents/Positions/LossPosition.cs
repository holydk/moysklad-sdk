using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an loss position.
    /// </summary>
    public class LossPosition : DocumentPosition
    {
        // todo
        //private List<String> things;

        #region Properties

        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        /// <value>The reason.</value>
        [JsonProperty("reason")]
        public string Reason { get; set; }

        #endregion
    }
}
