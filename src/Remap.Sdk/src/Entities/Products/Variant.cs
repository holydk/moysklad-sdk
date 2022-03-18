namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an variant.
    /// </summary>
    public class Variant : AbstractProduct
    {
        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is archived.
        /// </summary>
        /// <value>The value indicating whether to the entity is archived.</value>
        public bool? Archived { get; set; }

        /// <summary>
        /// Gets or sets the minimum price.
        /// </summary>
        /// <value>The minimum price.</value>
        public Price MinPrice { get; set; }

        /// <summary>
        /// Gets or sets the sale prices.
        /// </summary>
        /// <value>The sale prices.</value>
        public Price[] SalePrices { get; set; }

        /// <summary>
        /// Gets or sets the characteristics.
        /// </summary>
        /// <value>The characteristics.</value>
        public Characteristic[] Characteristics { get; set; }

        /// <summary>
        /// Gets or sets the images.
        /// </summary>
        /// <value>The images.</value>
        public PagedMetaEntities<Image> Images { get; set; }

        /// <summary>
        /// Gets or sets the buy price.
        /// </summary>
        /// <value>The buy price.</value>
        public Price BuyPrice { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>The product.</value>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the serial numbers.
        /// </summary>
        /// <value>The serial numbers.</value>
        public string[] Things { get; set; }
            
        #endregion
    }
}