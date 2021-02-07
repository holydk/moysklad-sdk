using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an good (e.g. product, service and bundle).
    /// </summary>
    public abstract class Goods : AbstractProduct, ISynchronizationSupported
    {
        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is archived.
        /// </summary>
        /// <value>The value indicating whether to the entity is archived.</value>
        [JsonProperty("archived")]
        public bool? Archived { get; set; }

        /// <summary>
        /// Gets or sets the minimum price.
        /// </summary>
        /// <value>The minimum price.</value>
        [JsonProperty("minPrice")]
        public Price MinPrice { get; set; }

        /// <summary>
        /// Gets or sets the sale prices.
        /// </summary>
        /// <value>The sale prices.</value>
        [JsonProperty("salePrices")]
        public Price[] SalePrices { get; set; }

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>The owner.</value>
        [JsonProperty("owner")]
        public Employee Owner { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is shared.
        /// </summary>
        /// <value>The value indicating whether to the entity is shared.</value>
        [JsonProperty("shared")]
        public bool? Shared { get; set; }

        /// <summary>
        /// Gets or sets the group.
        /// </summary>
        /// <value>The group.</value>
        [JsonProperty("group")]
        public Group Group { get; set; }

        /// <summary>
        /// Gets or sets the synchronization id.
        /// </summary>
        /// <value>The synchronization id.</value>
        [JsonProperty("syncId")]
        public string SyncId { get; set; }

        /// <summary>
        /// Gets or sets the path name.
        /// </summary>
        /// <value>The path name.</value>
        [JsonProperty("pathName")]
        public string PathName { get; set; }

        /// <summary>
        /// Gets or sets the vat.
        /// </summary>
        /// <value>The vat.</value>
        [JsonProperty("vat")]
        public int? Vat { get; set; }

        /// <summary>
        /// Gets or sets the effectiveVat vat.
        /// </summary>
        /// <value>The vat.</value>
        [JsonProperty("effectiveVat")]
        public int? EffectiveVat { get; set; }

        /// <summary>
        /// Gets or sets the product folder.
        /// </summary>
        /// <value>The product folder.</value>
        [JsonProperty("productFolder")]
        public ProductFolder ProductFolder { get; set; }

        /// <summary>
        /// Gets or sets the unit of measure.
        /// </summary>
        /// <value>The unit of measure.</value>
        [JsonProperty("uom")]
        public Uom Uom { get; set; }

        /// <summary>
        /// Gets or sets the buy price.
        /// </summary>
        /// <value>The buy price.</value>
        [JsonProperty("buyPrice")]
        public Price BuyPrice { get; set; }

        /// <summary>
        /// Gets or sets the attribute values.
        /// </summary>
        /// <value>The attribute values.</value>
        [JsonProperty("attributes")]
        public AttributeValue[] Attributes { get; set; }

        /// <summary>
        /// Gets or sets the product tax system.
        /// </summary>
        /// <value>The product tax system.</value>
        [JsonProperty("taxSystem")]
        public ProductTaxSystem? TaxSystem { get; set; }
            
        #endregion
    }
}