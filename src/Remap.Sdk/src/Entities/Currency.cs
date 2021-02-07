using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an currency.
    /// </summary>
    public class Currency : MetaEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>The full name.</value>
        [JsonProperty("fullName")]
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the iso code.
        /// </summary>
        /// <value>The iso code.</value>
        [JsonProperty("isoCode")]
        public string IsoCode { get; set; }

        /// <summary>
        /// Gets or sets the rate.
        /// </summary>
        /// <value>The rate.</value>
        [JsonProperty("rate")]
        public double? Rate { get; set; }

        /// <summary>
        /// Gets or sets the multiplicity.
        /// </summary>
        /// <value>The multiplicity.</value>
        [JsonProperty("multiplicity")]
        public int? Multiplicity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the currency is indirect.
        /// </summary>
        /// <value>The value indicating whether to the currency is indirect.</value>
        [JsonProperty("indirect")]
        public bool? Indirect { get; set; }

        /// <summary>
        /// Gets or sets the rate update type.
        /// </summary>
        /// <value>The rate update type.</value>
        [JsonProperty("rateUpdateType")]
        public string RateUpdateType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is archived.
        /// </summary>
        /// <value>The value indicating whether to the entity is archived.</value>
        [JsonProperty("archived")]
        public bool? Archived { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is system.
        /// </summary>
        /// <value>The value indicating whether to the entity is system.</value>
        [JsonProperty("system")]
        public bool? System { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is default.
        /// </summary>
        /// <value>The value indicating whether to the entity is default.</value>
        [JsonProperty("default")]
        public bool? Default { get; set; }
            
        #endregion
    }
}