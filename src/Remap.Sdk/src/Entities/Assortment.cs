using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an assortment.
    /// </summary>
    public class Assortment : MetaEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the abstract product.
        /// </summary>
        /// <value>The abstract product.</value>
        [JsonIgnore]
        public AbstractProduct Product { get; set; }

        /// <summary>
        /// Gets or sets the stock.
        /// </summary>
        /// <value>The stock.</value>
        public double? Stock { get; set; }

        /// <summary>
        /// Gets or sets the reserve.
        /// </summary>
        /// <value>The reserve.</value>
        public double? Reserve { get; set; }

        /// <summary>
        /// Gets or sets the count of the items in transit.
        /// </summary>
        /// <value>The count of the items in transit.</value>
        public double? InTransit { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public double? Quantity { get; set; }

        #endregion
    }
}