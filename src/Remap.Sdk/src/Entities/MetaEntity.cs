using System;
using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an entity containing <see cref="Meta"/>.
    /// </summary>
    public abstract class MetaEntity : IHasMeta<Meta>
    {
        #region Properties

        /// <summary>
        /// Gets the metadata about entity.
        /// </summary>
        /// <value>The metadata about entity.</value>
        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        /// <summary>
        /// Gets or sets the entity id.
        /// </summary>
        /// <value>The entity id.</value>
        [JsonProperty("id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the account id.
        /// </summary>
        /// <value>The account id.</value>
        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        /// <summary>
        /// Gets or sets the entity name.
        /// </summary>
        /// <value>The entity name.</value>
        [JsonProperty("name")]
        public string Name { get; set; }
            
        #endregion
    }
}