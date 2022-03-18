namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an bundle component.
    /// </summary>
    public class BundleComponent : MetaEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the abstract product.
        /// </summary>
        /// <value>The abstract product.</value>
        public AbstractProduct Assortment { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public double? Quantity { get; set; }
            
        #endregion
    }
}