using System.ComponentModel;
using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an purchase return.
    /// </summary>
    public class PurchaseReturn : Document
    {
        #region Properties

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the vat sum.
        /// </summary>
        /// <value>The vat sum.</value>
        [JsonProperty("vatSum")]
        public long? VatSum { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the vat is enabled.
        /// </summary>
        /// <value>The value indicating whether to the vat is enabled.</value>
        [JsonProperty("vatEnabled")]
        public bool? VatEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the vat is included.
        /// </summary>
        /// <value>The value indicating whether to the vat is included.</value>
        [JsonProperty("vatIncluded")]
        public bool? VatIncluded { get; set; }

        /// <summary>
        /// Gets or sets the project.
        /// </summary>
        /// <value>The project.</value>
        [JsonProperty("project")]
        public Project Project { get; set; }

        /// <summary>
        /// Gets or sets the rate.
        /// </summary>
        /// <value>The rate.</value>
        [JsonProperty("rate")]
        public Rate Rate { get; set; }

        /// <summary>
        /// Gets or sets the agent.
        /// </summary>
        /// <value>The agent.</value>
        [JsonProperty("agent")]
        public Counterparty Agent { get; set; }

        /// <summary>
        /// Gets or sets the agent account.
        /// </summary>
        /// <value>The agent account.</value>
        [JsonProperty("agentAccount")]
        public AgentAccount AgentAccount { get; set; }

        /// <summary>
        /// Gets or sets the store.
        /// </summary>
        /// <value>The store.</value>
        [JsonProperty("store")]
        public Store Store { get; set; }

        /// <summary>
        /// Gets or sets the contract.
        /// </summary>
        /// <value>The contract.</value>
        [JsonProperty("contract")]
        public Contract Contract { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        [JsonProperty("state")]
        public State State { get; set; }

        /// <summary>
        /// Gets or sets the organization account.
        /// </summary>
        /// <value>The organization account.</value>
        [JsonProperty("organizationAccount")]
        public AgentAccount OrganizationAccount { get; set; }

        /// <summary>
        /// Gets or sets the attribute values.
        /// </summary>
        /// <value>The attribute values.</value>
        [JsonProperty("attributes")]
        public AttributeValue[] Attributes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the document is published.
        /// </summary>
        /// <value>The value indicating whether to the document is published.</value>
        [JsonProperty("published")]
        public bool? Published { get; set; }

        /// <summary>
        /// Gets or sets the positions.
        /// </summary>
        /// <value>The positions.</value>
        [DefaultValue("{}")]
        [JsonProperty("positions", NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public PagedMetaEntities<PurchaseReturnPosition> Positions { get; set; } = new PagedMetaEntities<PurchaseReturnPosition>();

        /// <summary>
        /// Gets or sets the payed sum.
        /// </summary>
        /// <value>The payed sum.</value>
        [JsonProperty("payedSum")]
        public long? PayedSum { get; set; }

        /// <summary>
        /// Gets or sets the payments.
        /// </summary>
        /// <value>The payments.</value>
        [JsonProperty("payments")]
        public PaymentDocument[] Payments { get; set; }
            
        #endregion
    }
}