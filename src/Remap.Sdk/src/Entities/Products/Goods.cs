namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an good (e.g. product, service and bundle).
    /// </summary>
    public abstract class Goods : AbstractProduct, ISynchronizationSupported
    {
        #region Properties

        /// <summary>
        /// Gets or sets the attribute values.
        /// </summary>
        /// <value>The attribute values.</value>
        public AttributeValue[] Attributes { get; set; }

        /// <summary>
        /// Gets or sets the effectiveVat vat.
        /// </summary>
        /// <value>The vat.</value>
        public int? EffectiveVat { get; set; }

        /// <summary>
        /// Gets or sets the group.
        /// </summary>
        /// <value>The group.</value>
        public Group Group { get; set; }

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>The owner.</value>
        public Employee Owner { get; set; }

        /// <summary>
        /// Gets or sets the path name.
        /// </summary>
        /// <value>The path name.</value>
        public string PathName { get; set; }

        /// <summary>
        /// Gets or sets the product folder.
        /// </summary>
        /// <value>The product folder.</value>
        public ProductFolder ProductFolder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is shared.
        /// </summary>
        /// <value>The value indicating whether to the entity is shared.</value>
        public bool? Shared { get; set; }

        /// <summary>
        /// Gets or sets the synchronization id.
        /// </summary>
        /// <value>The synchronization id.</value>
        public string SyncId { get; set; }

        /// <summary>
        /// Gets or sets the product tax system.
        /// </summary>
        /// <value>The product tax system.</value>
        public ProductTaxSystem? TaxSystem { get; set; }

        /// <summary>
        /// Gets or sets the unit of measure.
        /// </summary>
        /// <value>The unit of measure.</value>
        public Uom Uom { get; set; }

        /// <summary>
        /// Gets or sets the vat.
        /// </summary>
        /// <value>The vat.</value>
        public int? Vat { get; set; }

        #endregion Properties
    }
}
