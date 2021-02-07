using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an discount.
    /// </summary>
    public class Discount : MetaEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether to the discount is active.
        /// </summary>
        /// <value>The value indicating whether to the discount is active.</value>
        [JsonProperty("active")]
        public bool? Active { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the discount is applied to all products.
        /// </summary>
        /// <value>The value indicating whether to the discount is applied to all products.</value>
        [JsonProperty("allProducts")]
        public bool? AllProducts { get; set; }

        /// <summary>
        /// Gets or sets the agent tags.
        /// </summary>
        /// <value>The agent tags.</value>
        [JsonProperty("agentTags")]
        public string[] AgentTags { get; set; }

        /// <summary>
        /// Gets or sets the assortment.
        /// </summary>
        /// <value>The assortment.</value>
        [JsonProperty("assortment")]
        public AbstractProduct[] Assortment { get; set; }
            
        #endregion
    }
}