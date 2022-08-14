using System;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an note.
    /// </summary>
    public class CounterpartyNote : MetaEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the date when the entity has been created.
        /// </summary>
        /// <value>The date when the entity has been created.</value>
        public DateTime? Created { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the agent.
        /// </summary>
        /// <value>The agent.</value>
        public Counterparty Agent { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>The author.</value>
        public Employee Author { get; set; }
            
        #endregion
    }
}