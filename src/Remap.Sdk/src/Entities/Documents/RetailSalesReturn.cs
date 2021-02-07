using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an retail sales return.
    /// </summary>
    public class RetailSalesReturn : Document
    {
        // todo
        //private RetailShift retailShift;
        //private RetailStore retailStore;

        #region Properties

        /// <summary>
        /// Gets or sets the cash sum.
        /// </summary>
        /// <value>The cash sum.</value>
        [JsonProperty("cashSum")]
        public long? CashSum { get; set; }

        /// <summary>
        /// Gets or sets the 'no cash' sum.
        /// </summary>
        /// <value>The 'no cash' sum.</value>
        [JsonProperty("noCashSum")]
        public long? NoCashSum { get; set; }

        /// <summary>
        /// Gets or sets the retail demand.
        /// </summary>
        /// <value>The retail demand.</value>
        [JsonProperty("demand")]
        public RetailDemand Demand { get; set; }

        /// <summary>
        /// Gets or sets the date when the entity has been created.
        /// </summary>
        /// <value>The date when the entity has been created.</value>
        [JsonProperty("created")]
        public DateTime? Created { get; set; }

        /// <summary>
        /// Gets or sets the date when the entity has been deleted.
        /// </summary>
        /// <value>The date when the entity has been deleted.</value>
        [JsonProperty("deleted")]
        public DateTime? Deleted { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the external code.
        /// </summary>
        /// <value>The external code.</value>
        [JsonProperty("externalCode")]
        public string ExternalCode { get; set; }

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
        /// Gets or sets the rate.
        /// </summary>
        /// <value>The rate.</value>
        [JsonProperty("rate")]
        public Rate Rate { get; set; }

        /// <summary>
        /// Gets or sets the project.
        /// </summary>
        /// <value>The project.</value>
        [JsonProperty("project")]
        public Project Project { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        [JsonProperty("state")]
        public State State { get; set; }

        /// <summary>
        /// Gets or sets the contract.
        /// </summary>
        /// <value>The contract.</value>
        [JsonProperty("contract")]
        public Contract Contract { get; set; }

        /// <summary>
        /// Gets or sets the store.
        /// </summary>
        /// <value>The store.</value>
        [JsonProperty("store")]
        public Store Store { get; set; }

        /// <summary>
        /// Gets or sets the organization.
        /// </summary>
        /// <value>The organization.</value>
        [JsonProperty("organization")]
        public Organization Organization { get; set; }

        /// <summary>
        /// Gets or sets the organization account.
        /// </summary>
        /// <value>The organization account.</value>
        [JsonProperty("organizationAccount")]
        public AgentAccount OrganizationAccount { get; set; }

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
        /// Gets or sets the attribute values.
        /// </summary>
        /// <value>The attribute values.</value>
        [JsonProperty("attributes")]
        public AttributeValue[] Attributes { get; set; }

        /// <summary>
        /// Gets or sets the positions.
        /// </summary>
        /// <value>The positions.</value>
        [DefaultValue("{}")]
        [JsonProperty("positions", NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public PagedMetaEntities<RetailSalesPosition> Positions { get; set; } = new PagedMetaEntities<RetailSalesPosition>();

        /// <summary>
        /// Gets or sets the tax system.
        /// </summary>
        /// <value>The tax system.</value>
        [JsonProperty("taxSystem")]
        public DocumentTaxSystem? TaxSystem { get; set; }

        #endregion
    }
}
