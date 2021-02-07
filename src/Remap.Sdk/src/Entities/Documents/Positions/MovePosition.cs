using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an move position.
    /// </summary>
    public class MovePosition : DocumentPosition
    {
        // todo
        //private List<String> things;

        #region Properties

        /// <summary>
        /// Gets or sets the overhead.
        /// </summary>
        /// <value>The overhead.</value>
        [JsonProperty("overhead")]
        public long? Overhead { get; set; }

        #endregion
    }
}
