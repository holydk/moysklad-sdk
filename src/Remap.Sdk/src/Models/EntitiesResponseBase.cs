using Confetti.MoySklad.Remap.Entities;
using Newtonsoft.Json;

namespace Confetti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents the response containing the list of entities with <see cref="Context"/> and <see cref="PagedMeta"/>.
    /// </summary>
    /// <typeparam name="T">The type of entity.</typeparam>
    public abstract class EntitiesResponseBase<T> : PagedMetaEntities<T>, IHasContext where T : MetaEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the response context.
        /// </summary>
        /// <value>The response context.</value>
        [JsonProperty("context", Required = Required.DisallowNull)]
        public Context Context { get; set; }
            
        #endregion
    }
}