using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an bundle.
    /// </summary>
    public class PhysicalGoods : Goods
    {
        #region Properties

        /// <summary>
        /// Gets or sets the images.
        /// </summary>
        /// <value>The images.</value>
        [JsonProperty("images")]
        public PagedMetaEntities<Image> Images { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        [JsonProperty("country")]
        public Country Country { get; set; }

        /// <summary>
        /// Gets or sets the article.
        /// </summary>
        /// <value>The article.</value>
        [JsonProperty("article")]
        public string Article { get; set; }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>The weight.</value>
        [JsonProperty("weight")]
        public double? Weight { get; set; }

        /// <summary>
        /// Gets or sets the volume.
        /// </summary>
        /// <value>The volume.</value>
        [JsonProperty("volume")]
        public double? Volume { get; set; }

        /// <summary>
        /// Gets or sets the tracking type.
        /// </summary>
        /// <value>The tracking type.</value>
        [JsonProperty("trackingType")]
        public TrackingType? TrackingType { get; set; }

        /// <summary>
        /// Gets or sets the tnved.
        /// </summary>
        /// <value>The tnved.</value>
        [JsonProperty("tnved")]
        public string Tnved { get; set; }

        /// <summary>
        /// Gets or sets the payment item type.
        /// </summary>
        /// <value>The payment item type.</value>
        [JsonProperty("paymentItemType")]
        public PhysicalGoodsPaymentItemType? PaymentItemType { get; set; }
            
        #endregion
    }
}