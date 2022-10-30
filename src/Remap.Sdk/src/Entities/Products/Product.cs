namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an product.
    /// </summary>
    public class Product : PhysicalGoods
    {
        #region Properties

        /// <summary>
        /// Gets or sets the alcoholic product information.
        /// </summary>
        /// <value>The alcoholic product information.</value>
        public Alcoholic Alcoholic { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is serial trackable.
        /// </summary>
        /// <value>The value indicating whether to the entity is serial trackable.</value>
        public bool? IsSerialTrackable { get; set; }

        /// <summary>
        /// Gets or sets the minimum balance.
        /// </summary>
        /// <value>The minimum balance.</value>
        public double? MinimumBalance { get; set; }

        /// <summary>
        /// Gets or sets the packs.
        /// </summary>
        /// <value>The packs.</value>
        public Pack[] Packs { get; set; }

        /// <summary>
        /// Gets or sets the supplier.
        /// </summary>
        /// <value>The supplier.</value>
        public Counterparty Supplier { get; set; }

        /// <summary>
        /// Gets or sets the serial numbers.
        /// </summary>
        /// <value>The serial numbers.</value>
        public string[] Things { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the product is tobacco.
        /// </summary>
        /// <value>The value indicating whether to the entity is tobacco.</value>
        public bool? Tobacco { get; set; }

        /// <summary>
        /// Gets or sets the variants count.
        /// </summary>
        /// <value>The variants count.</value>
        public int? VariantsCount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is weighed.
        /// </summary>
        /// <value>The value indicating whether to the entity is weighed.</value>
        public bool? Weighed { get; set; }

        #endregion Properties
    }
}