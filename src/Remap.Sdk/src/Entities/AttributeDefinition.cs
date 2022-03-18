namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an attribute definition.
    /// </summary>
    public class AttributeDefinition : AbstractAttribute
    {
        #region Properties

        /// <summary>
        /// Gets or sets the custom entity meta.
        /// </summary>
        /// <value>The custom entity meta.</value>
        public Meta CustomEntityMeta { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the attribute is required.
        /// </summary>
        /// <value>The value indicating whether to the attribute is required.</value>
        public bool? Required { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }
            
        #endregion
    }
}