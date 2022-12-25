namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents the model containing the list of entities with T.
    /// </summary>
    public class PagedEntities<T> where T : class
    {
        #region Property

        /// <summary>
        /// Gets or sets the array of entities.
        /// </summary>
        /// <value>The array of entities.</value>
        public T[] Rows { get; set; }

        #endregion Property
    }
}