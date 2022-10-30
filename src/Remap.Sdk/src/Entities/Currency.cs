namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an currency.
    /// </summary>
    public class Currency : MetaEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is archived.
        /// </summary>
        /// <value>The value indicating whether to the entity is archived.</value>
        public bool? Archived { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is default.
        /// </summary>
        /// <value>The value indicating whether to the entity is default.</value>
        public bool? Default { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>The full name.</value>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the currency is indirect.
        /// </summary>
        /// <value>The value indicating whether to the currency is indirect.</value>
        public bool? Indirect { get; set; }

        /// <summary>
        /// Gets or sets the iso code.
        /// </summary>
        /// <value>The iso code.</value>
        public string IsoCode { get; set; }

        /// <summary>
        /// Gets or sets the multiplicity.
        /// </summary>
        /// <value>The multiplicity.</value>
        public int? Multiplicity { get; set; }

        /// <summary>
        /// Gets or sets the rate.
        /// </summary>
        /// <value>The rate.</value>
        public double? Rate { get; set; }

        /// <summary>
        /// Gets or sets the rate update type.
        /// </summary>
        /// <value>The rate update type.</value>
        public string RateUpdateType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is system.
        /// </summary>
        /// <value>The value indicating whether to the entity is system.</value>
        public bool? System { get; set; }

        #endregion Properties
    }
}