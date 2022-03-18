namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an operation.
    /// </summary>
    public class Operation : IHasMeta<Meta>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the link to the operation to which this payment is linked.
        /// </summary>
        /// <value>The link to the operation to which this payment is linked.</value>
        public Meta Meta { get; set; }

        /// <summary>
        /// Gets or sets the linked sum.
        /// </summary>
        /// <value>The linked sum.</value>
        public long? LinkedSum { get; set; }

        #endregion
    }
}