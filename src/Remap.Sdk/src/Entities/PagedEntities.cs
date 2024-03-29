namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents the model containing the list of entities with <see cref="PagedMeta"/>.
    /// </summary>
    public class PagedEntities<T> : IHasMeta<PagedMeta>
    {
        #region Properties

        /// <summary>
        /// Gets the paged metadata.
        /// </summary>
        /// <value>The paged metadata.</value>
        public PagedMeta Meta { get; set; }

        /// <summary>
        /// Gets or sets the array of entities.
        /// </summary>
        /// <value>The array of entities.</value>
        public T[] Rows { get; set; }

        #endregion Properties
    }
}