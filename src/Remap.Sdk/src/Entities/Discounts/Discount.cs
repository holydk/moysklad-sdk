namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an discount.
    /// </summary>
    public class Discount : MetaEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether to the discount is active.
        /// </summary>
        /// <value>The value indicating whether to the discount is active.</value>
        public bool? Active { get; set; }

        /// <summary>
        /// Gets or sets the agent tags.
        /// </summary>
        /// <value>The agent tags.</value>
        public string[] AgentTags { get; set; }

        #endregion Properties
    }
}