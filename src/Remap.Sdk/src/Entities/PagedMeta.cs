using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents the paged metadata about entity.
    /// </summary>
    public class PagedMeta : Meta
    {
        #region Properties

        /// <summary>
        /// Gets or sets the list size.
        /// </summary>
        /// <value>The list size.</value>
        [JsonProperty("size")]
        public int Size { get; set; }

        /// <summary>
        /// Gets or sets the max number of items in the list.
        /// </summary>
        /// <value>The max number of items in the list.</value>
        [JsonProperty("limit")]
        public int Limit { get; set; }

        /// <summary>
        /// Gets or sets the offset in the list.
        /// </summary>
        /// <value>The offset in the list.</value>
        [JsonProperty("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets the reference to the next entity page.
        /// </summary>
        /// <value>The reference to the next entity page.</value>
        [JsonProperty("nextHref")]
        public string NextHref { get; set; }

        /// <summary>
        /// Gets or sets the reference to the previous entity page.
        /// </summary>
        /// <value>The reference to the previous entity page.</value>
        [JsonProperty("previousHref")]
        public string PreviousHref { get; set; }
            
        #endregion
    }
}