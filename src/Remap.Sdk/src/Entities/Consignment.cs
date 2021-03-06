using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an consignment.
    /// </summary>
    public class Consignment : AbstractProduct
    {
        #region Properties

        /// <summary>
        /// Gets or sets the assortment (e.g <see cref="Product" /> or <see cref="Variant" />).
        /// </summary>
        /// <value>The assortment.</value>
        [JsonProperty("assortment")]
        public AbstractProduct Assortment { get; set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>The label.</value>
        [JsonProperty("label")]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        [JsonProperty("image")]
        public Image Image { get; set; }
            
        #endregion
    }
}