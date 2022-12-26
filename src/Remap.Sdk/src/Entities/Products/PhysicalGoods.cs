namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an bundle.
    /// </summary>
    public class PhysicalGoods : Goods
    {
        #region Properties

        /// <summary>
        /// Gets or sets the article.
        /// </summary>
        /// <value>The article.</value>
        public string Article { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        public Country Country { get; set; }

        /// <summary>
        /// Gets or sets the images.
        /// </summary>
        /// <value>The images.</value>
        public PagedEntities<Image> Images { get; set; }

        /// <summary>
        /// Gets or sets the payment item type.
        /// </summary>
        /// <value>The payment item type.</value>
        public PhysicalGoodsPaymentItemType? PaymentItemType { get; set; }

        /// <summary>
        /// Gets or sets the tnved.
        /// </summary>
        /// <value>The tnved.</value>
        public string Tnved { get; set; }

        /// <summary>
        /// Gets or sets the tracking type.
        /// </summary>
        /// <value>The tracking type.</value>
        public TrackingType? TrackingType { get; set; }

        /// <summary>
        /// Gets or sets the volume.
        /// </summary>
        /// <value>The volume.</value>
        public double? Volume { get; set; }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>The weight.</value>
        public double? Weight { get; set; }

        #endregion Properties
    }
}