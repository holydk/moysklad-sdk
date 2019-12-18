using Confetti.MoySklad.Remap.Entities;
using Newtonsoft.Json;

namespace Confetti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents the response containing the list of entities with <see cref="Context"/> and <see cref="PagedMeta"/>.
    /// </summary>
    /// <typeparam name="T">The type of entity.</typeparam>
    public abstract class ListEntityResponseBase<T> : IHasContext, IHasMeta<PagedMeta> where T : class
    {
        #region Properties

        /// <summary>
        /// Gets or sets the response context.
        /// </summary>
        /// <value>The response context.</value>
        [JsonProperty("context", Required = Required.Always)]
        public Context Context { get; set; }
        
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
        [JsonProperty("rows", Required = Required.Always)]
        public T[] Rows { get; set; }
            
        #endregion
    }
}