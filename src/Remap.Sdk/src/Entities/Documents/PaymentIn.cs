using System;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an payment in.
    /// </summary>
    public class PaymentIn : PaymentDocument
    {
        #region Properties

        /// <summary>
        /// Gets or sets the incoming date.
        /// </summary>
        /// <value>The incoming date.</value>
        public DateTime? IncomingDate { get; set; }

        /// <summary>
        /// Gets or sets the incoming number.
        /// </summary>
        /// <value>The incoming number.</value>
        public string IncomingNumber { get; set; }

        /// <summary>
        /// Gets or sets the agent account.
        /// </summary>
        /// <value>The agent account.</value>
        public AgentAccount AgentAccount { get; set; }

        /// <summary>
        /// Gets or sets the organization account.
        /// </summary>
        /// <value>The organization account.</value>
        public AgentAccount OrganizationAccount { get; set; }

        /// <summary>
        /// Gets or sets the operations.
        /// </summary>
        /// <value>The operations.</value>
        public Operation[] Operations { get; set; }
            
        #endregion
    }
}