namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an state.
    /// </summary>
    public class State : MetaEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        public int? Color { get; set; }

        /// <summary>
        /// Gets or sets the entity type.
        /// </summary>
        /// <value>The entity type.</value>
        public EntityType? EntityType { get; set; }

        /// <summary>
        /// Gets or sets the state type.
        /// </summary>
        /// <value>The state type.</value>
        public StateType? StateType { get; set; }

        #endregion Properties
    }
}