using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an retail demand.
    /// </summary>
    public class RetailDemand : Document
    {
        #region Properties

        // todo
        //private RetailShift retailShift;
        //private RetailStore retailStore;

        /// <summary>
        /// Gets or sets the prepayment cash sum.
        /// </summary>
        /// <value>The prepayment cash sum.</value>
        [JsonProperty("prepaymentCashSum")]
        public long? PrepaymentCashSum { get; set; }

        /// <summary>
        /// Gets or sets the prepayment 'no cash' sum.
        /// </summary>
        /// <value>The prepayment 'no cash' sum.</value>
        [JsonProperty("prepaymentNoCashSum")]
        public long? PrepaymentNoCashSum { get; set; }

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
        /// Gets or sets the customer order.
        /// </summary>
        /// <value>The customer order.</value>
        [JsonProperty("customerOrder")]
        public CustomerOrder CustomerOrder { get; set; }

        /// <summary>
        /// Gets or sets the payed sum.
        /// </summary>
        /// <value>The payed sum.</value>
        [JsonProperty("payedSum")]
        public long? PayedSum { get; set; }

        /// <summary>
        /// Gets or sets the ODF code.
        /// </summary>
        /// <value>The ODF code.</value>
        [JsonProperty("ofdCode")]
        public string OfdCode { get; set; }

        /// <summary>
        /// Gets or sets the session number.
        /// </summary>
        /// <value>The session number.</value>
        [JsonProperty("sessionNumber")]
        public string SessionNumber { get; set; }

        /// <summary>
        /// Gets or sets the check number.
        /// </summary>
        /// <value>The check number.</value>
        [JsonProperty("checkNumber")]
        public string CheckNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the document fiscalization processed.
        /// </summary>
        /// <value>The value indicating whether to the document fiscalization processed.</value>
        [JsonProperty("fiscal")]
        public bool? Fiscal { get; set; }

        /// <summary>
        /// Gets or sets the check sum.
        /// </summary>
        /// <value>The check sum.</value>
        [JsonProperty("checkSum")]
        public long? CheckSum { get; set; }

        /// <summary>
        /// Gets or sets the document number.
        /// </summary>
        /// <value>The document number.</value>
        [JsonProperty("documentNumber")]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets the fiscal printer info.
        /// </summary>
        /// <value>The fiscal printer info.</value>
        [JsonProperty("fiscalPrinterInfo")]
        public string FiscalPrinterInfo { get; set; }

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
