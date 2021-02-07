using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an document overhead.
    /// </summary>
    public class DocumentOverhead
    {
        #region Properties

        /// <summary>
        /// Gets or sets the sum.
        /// </summary>
        /// <value>The sum.</value>
        [JsonProperty("sum")]
        public long? Sum { get; set; }

        /// <summary>
        /// Gets or sets the overhead distribution type.
        /// </summary>
        /// <value>The overhead distribution type.</value>
        [JsonProperty("distribution")]
        public OverheadDistributionType? DistributionType { get; set; }

        #endregion
    }
}
