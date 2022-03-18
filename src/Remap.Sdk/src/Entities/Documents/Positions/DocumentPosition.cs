namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an document position.
    /// </summary>
    public abstract class DocumentPosition : MetaEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public double? Quantity { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        public long? Price { get; set; }

        /// <summary>
        /// Gets or sets the assortment.
        /// </summary>
        /// <value>The assortment.</value>
        public AbstractProduct Assortment { get; set; }

        /// <summary>
        /// Gets or sets the pack.
        /// </summary>
        /// <value>The pack.</value>
        public Pack Pack { get; set; }
            
        #endregion
    }
}