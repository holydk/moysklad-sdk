using System;
using Newtonsoft.Json;

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
        [JsonProperty("incomingDate")]
        public DateTime? IncomingDate { get; set; }

        /// <summary>
        /// Gets or sets the incoming number.
        /// </summary>
        /// <value>The incoming number.</value>
        [JsonProperty("incomingNumber")]
        public string IncomingNumber { get; set; }

        /// <summary>
        /// Gets or sets the agent account.
        /// </summary>
        /// <value>The agent account.</value>
        [JsonProperty("agentAccount")]
        public AgentAccount AgentAccount { get; set; }

        /// <summary>
        /// Gets or sets the organization account.
        /// </summary>
        /// <value>The organization account.</value>
        [JsonProperty("organizationAccount")]
        public AgentAccount OrganizationAccount { get; set; }

        /// <summary>
        /// Gets or sets the operations.
        /// </summary>
        /// <value>The operations.</value>
        [JsonProperty("operations")]
        public Operation[] Operations { get; set; }
            
        #endregion
    }
}