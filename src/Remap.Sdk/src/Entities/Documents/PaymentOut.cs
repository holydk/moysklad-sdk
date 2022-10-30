namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an payment out.
    /// </summary>
    public class PaymentOut : PaymentDocument
    {
        #region Properties

        /// <summary>
        /// Gets or sets the agent account.
        /// </summary>
        /// <value>The agent account.</value>
        public AgentAccount AgentAccount { get; set; }

        /// <summary>
        /// Gets or sets the expense item.
        /// </summary>
        /// <value>The expense item.</value>
        public ExpenseItem ExpenseItem { get; set; }

        /// <summary>
        /// Gets or sets the operations.
        /// </summary>
        /// <value>The operations.</value>
        public Operation[] Operations { get; set; }

        /// <summary>
        /// Gets or sets the organization account.
        /// </summary>
        /// <value>The organization account.</value>
        public AgentAccount OrganizationAccount { get; set; }

        #endregion Properties
    }
}