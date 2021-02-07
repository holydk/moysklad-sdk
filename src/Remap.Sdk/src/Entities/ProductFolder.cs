using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an product folder.
    /// </summary>
    public class ProductFolder : MetaEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is shared.
        /// </summary>
        /// <value>The value indicating whether to the entity is shared.</value>
        [JsonProperty("shared")]
        public bool? Shared { get; set; }

        /// <summary>
        /// Gets or sets the path name.
        /// </summary>
        /// <value>The path name.</value>
        [JsonProperty("pathName")]
        public string PathName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is archived.
        /// </summary>
        /// <value>The value indicating whether to the entity is archived.</value>
        [JsonProperty("archived")]
        public bool? Archived { get; set; }

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
        /// Gets or sets the date when the entity has been updated.
        /// </summary>
        /// <value>The date when the entity has been updated.</value>
        [JsonProperty("updated")]
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the external code.
        /// </summary>
        /// <value>The external code.</value>
        [JsonProperty("externalCode")]
        public string ExternalCode { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the product folder.
        /// </summary>
        /// <value>The product folder.</value>
        [DefaultValue("{}")]
        [JsonProperty("productFolder", NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ProductFolder Folder { get; set; }

        /// <summary>
        /// Gets or sets the product tax system.
        /// </summary>
        /// <value>The product tax system.</value>
        [JsonProperty("taxSystem")]
        public ProductTaxSystem? TaxSystem { get; set; }

        #endregion
    }
}