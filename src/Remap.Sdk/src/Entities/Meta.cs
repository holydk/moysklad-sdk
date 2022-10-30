namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents the metadata about entity.
    /// </summary>
    public class Meta
    {
        #region Properties

        /// <summary>
        /// Gets or sets the download reference.
        /// </summary>
        /// <value>The download reference.</value>
        public string DownloadHref { get; set; }

        /// <summary>
        /// Gets or sets the entity reference.
        /// </summary>
        /// <value>The entity reference.</value>
        public string Href { get; set; }

        /// <summary>
        /// Gets or sets the media type.
        /// </summary>
        /// <value>The media type.</value>
        public string MediaType { get; set; }

        /// <summary>
        /// Gets or sets the entity metadata reference.
        /// </summary>
        /// <value>The entity metadata reference.</value>
        public string MetadataHref { get; set; }

        /// <summary>
        /// Gets or sets the type of entity.
        /// </summary>
        /// <value>The type of entity.</value>
        public EntityType Type { get; set; }

        /// <summary>
        /// Gets or sets the entity reference located in the UI.
        /// </summary>
        /// <value>The entity reference located on UI.</value>
        public string UuidHref { get; set; }

        #endregion Properties
    }
}