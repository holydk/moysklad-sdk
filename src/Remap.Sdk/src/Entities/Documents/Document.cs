using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an document.
    /// </summary>
    public abstract class Document : MetaEntity, ISynchronizationSupported
    {
        #region Properties

        /// <summary>
        /// Gets or sets the date when the entity has been updated.
        /// </summary>
        /// <value>The date when the entity has been updated.</value>
        [JsonProperty("updated")]
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is shared.
        /// </summary>
        /// <value>The value indicating whether to the entity is shared.</value>
        [JsonProperty("shared")]
        public bool? Shared { get; set; }

        /// <summary>
        /// Gets or sets the synchronization id.
        /// </summary>
        /// <value>The synchronization id.</value>
        [JsonProperty("syncId")]
        public string SyncId { get; set; }

        /// <summary>
        /// Gets or sets the date when the document has been placed.
        /// </summary>
        /// <value>The date when the document has been placed.</value>
        [JsonProperty("moment")]
        public DateTime? Moment { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the document is applicable.
        /// </summary>
        /// <value>The value indicating whether to the document is applicable.</value>
        [JsonProperty("applicable")]
        public bool? Applicable { get; set; }

        /// <summary>
        /// Gets or sets the total sum.
        /// </summary>
        /// <value>The total sum.</value>
        [JsonProperty("sum")]
        public long? Sum { get; set; }

        /// <summary>
        /// Gets or sets the group.
        /// </summary>
        /// <value>The group.</value>
        [JsonProperty("group")]
        public Group Group { get; set; }

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>The owner.</value>
        [DefaultValue("{}")]
        [JsonProperty("owner", NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Employee Owner { get; set; } = new Employee();
            
        #endregion
    }
}