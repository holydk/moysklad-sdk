using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an bundle.
    /// </summary>
    public class Bundle : PhysicalGoods
    {
        #region Properties

        /// <summary>
        /// Gets or sets the overhead.
        /// </summary>
        /// <value>The overhead.</value>
        [JsonProperty("overhead")]
        public Overhead Overhead { get; set; }

        /// <summary>
        /// Gets or sets the components.
        /// </summary>
        /// <value>The components.</value>
        [JsonProperty("components")]
        public PagedMetaEntities<BundleComponent> Components { get; set; }
            
        #endregion
    }
}