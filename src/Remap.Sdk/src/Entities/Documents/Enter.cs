using Newtonsoft.Json;
using System.ComponentModel;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an enter.
    /// </summary>
    public class Enter : Document
    {
        #region Properties

        /// <summary>
        /// Gets or sets the agent.
        /// </summary>
        /// <value>The agent.</value>
        public Counterparty Agent { get; set; }

        /// <summary>
        /// Gets or sets the agent account.
        /// </summary>
        /// <value>The agent account.</value>
        public AgentAccount AgentAccount { get; set; }

        /// <summary>
        /// Gets or sets the attribute values.
        /// </summary>
        /// <value>The attribute values.</value>
        public AttributeValue[] Attributes { get; set; }

        /// <summary>
        /// Gets or sets the contract.
        /// </summary>
        /// <value>The contract.</value>
        public Contract Contract { get; set; }

        /// <summary>
        /// Gets or sets the organization account.
        /// </summary>
        /// <value>The organization account.</value>
        public AgentAccount OrganizationAccount { get; set; }

        /// <summary>
        /// Gets or sets the overhead.
        /// </summary>
        /// <value>The overhead.</value>
        public DocumentOverhead Overhead { get; set; }

        /// <summary>
        /// Gets or sets the positions.
        /// </summary>
        /// <value>The positions.</value>
        [DefaultValue("{}")]
        [JsonProperty(NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public PagedMetaEntities<EnterPosition> Positions { get; set; } = new PagedMetaEntities<EnterPosition>();

        /// <summary>
        /// Gets or sets the project.
        /// </summary>
        /// <value>The project.</value>
        public Project Project { get; set; }

        /// <summary>
        /// Gets or sets the rate.
        /// </summary>
        /// <value>The rate.</value>
        public Rate Rate { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public State State { get; set; }

        /// <summary>
        /// Gets or sets the store.
        /// </summary>
        /// <value>The store.</value>
        public Store Store { get; set; }

        #endregion Properties
    }
}