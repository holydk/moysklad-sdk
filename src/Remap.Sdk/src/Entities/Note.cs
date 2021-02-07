using System;
using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an note.
    /// </summary>
    public class Note : MetaEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the date when the entity has been created.
        /// </summary>
        /// <value>The date when the entity has been created.</value>
        [JsonProperty("created")]
        public DateTime? Created { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the agent.
        /// </summary>
        /// <value>The agent.</value>
        [JsonProperty("agent")]
        public Counterparty Agent { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>The author.</value>
        [JsonProperty("author")]
        public Employee Author { get; set; }
            
        #endregion
    }
}