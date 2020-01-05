using System;
using Newtonsoft.Json;

namespace Confetti.MoySklad.Remap.Entities
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
        [JsonProperty("meta", Required = Required.Always)]
        public Meta Meta { get; set; }

        /// <summary>
        /// Gets or sets the entity id.
        /// </summary>
        /// <value>The entity id.</value>
        [JsonProperty("id", Required = Required.DisallowNull)]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the account id.
        /// </summary>
        /// <value>The account id.</value>
        [JsonProperty("accountId", Required = Required.DisallowNull)]
        public string AccountId { get; set; }

        /// <summary>
        /// Gets or sets the entity name.
        /// </summary>
        /// <value>The entity name.</value>
        [JsonProperty("name", Required = Required.DisallowNull)]
        public string Name { get; set; }
            
        #endregion
    }
}