namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an bundle.
    /// </summary>
    public class Bundle : PhysicalGoods
    {
        #region Properties

        /// <summary>
        /// Gets or sets the components.
        /// </summary>
        /// <value>The components.</value>
        public PagedEntities<BundleComponent> Components { get; set; }

        /// <summary>
        /// Gets or sets the overhead.
        /// </summary>
        /// <value>The overhead.</value>
        public Overhead Overhead { get; set; }

        #endregion Properties
    }
}