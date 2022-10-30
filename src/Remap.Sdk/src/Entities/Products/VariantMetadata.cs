namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an variant metadata.
    /// </summary>
    public class VariantMetadata : MetaEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the characteristics.
        /// </summary>
        /// <value>The characteristics.</value>
        public Characteristic[] Characteristics { get; set; }

        #endregion Properties
    }
}