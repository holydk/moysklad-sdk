using System;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an region.
    /// </summary>
    public class Region : MetaEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the external code.
        /// </summary>
        /// <value>The external code.</value>
        public string ExternalCode { get; set; }

        /// <summary>
        /// Gets or sets the date when the entity has been updated.
        /// </summary>
        /// <value>The date when the entity has been updated.</value>
        public DateTime? Updated { get; set; }

        #endregion Properties
    }
}