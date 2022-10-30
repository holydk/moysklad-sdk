namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an discount for assortment.
    /// </summary>
    public class GoodDiscount : Discount
    {
        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether to the discount is applied to all products.
        /// </summary>
        /// <value>The value indicating whether to the discount is applied to all products.</value>
        public bool? AllProducts { get; set; }

        /// <summary>
        /// Gets or sets the assortment.
        /// </summary>
        /// <value>The assortment.</value>
        public AbstractProduct[] Assortment { get; set; }

        /// <summary>
        /// Gets or sets the product folders.
        /// </summary>
        /// <value>The product folders.</value>
        public ProductFolder[] ProductFolders { get; set; }

        #endregion Properties
    }
}