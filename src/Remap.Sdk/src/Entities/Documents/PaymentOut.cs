using Newtonsoft.Json;

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