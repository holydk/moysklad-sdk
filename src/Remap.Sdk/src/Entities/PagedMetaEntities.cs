using Newtonsoft.Json;

namespace Confetti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents the model containing the list of entities with <see cref="PagedMeta"/>.
    /// </summary>
    public class PagedMetaEntities<T> : IHasMeta<PagedMeta> where T : MetaEntity
    {
        #region Property

        /// <summary>
        /// Gets the paged metadata about entity.
        /// </summary>
        /// <value>The paged metadata about entity.</value>
        [JsonProperty("meta", Required = Required.Always)]
        public PagedMeta Meta { get; set; }

        /// <summary>
        /// Gets or sets the array of entities.
        /// </summary>
        /// <value>The array of entities.</value>
        [JsonProperty("rows", Required = Required.DisallowNull)]
        public T[] Rows { get; set; }
            
        #endregion
    }
}