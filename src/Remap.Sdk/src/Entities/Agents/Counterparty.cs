using System;
using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an counterparty.
    /// </summary>
    public class Counterparty : MetaEntity
    {
        #region Properties

        #region Common

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the synchronization id.
        /// </summary>
        /// <value>The synchronization id.</value>
        [JsonProperty("syncId")]
        public string SyncId { get; set; }

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
        /// Gets or sets a value indicating whether to the entity is archived.
        /// </summary>
        /// <value>The value indicating whether to the entity is archived.</value>
        [JsonProperty("archived")]
        public bool? Archived { get; set; }

        /// <summary>
        /// Gets or sets the date when the entity has been updated.
        /// </summary>
        /// <value>The date when the entity has been updated.</value>
        [JsonProperty("updated")]
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is shared.
        /// </summary>
        /// <value>The value indicating whether to the entity is shared.</value>
        [JsonProperty("shared")]
        public bool? Shared { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the fax.
        /// </summary>
        /// <value>The fax.</value>
        [JsonProperty("fax")]
        public string Fax { get; set; }

        /// <summary>
        /// Gets or sets the actual address.
        /// </summary>
        /// <value>The actual address.</value>
        [JsonProperty("actualAddress")]
        public string ActualAddress { get; set; }

        /// <summary>
        /// Gets or sets the actual address full.
        /// </summary>
        /// <value>The actual address full.</value>
        [JsonProperty("actualAddressFull")]
        public Address ActualAddressFull { get; set; }

        /// <summary>
        /// Gets or sets the company type.
        /// </summary>
        /// <value>The company type.</value>
        [JsonProperty("companyType")]
        public CompanyType? CompanyType { get; set; }

        /// <summary>
        /// Gets or sets the group.
        /// </summary>
        /// <value>The group.</value>
        [JsonProperty("group")]
        public Group Group { get; set; }

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>The owner.</value>
        [JsonProperty("owner")]
        public Employee Owner { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        [JsonProperty("notes")]
        public PagedMetaEntities<Note> Notes { get; set; }

        /// <summary>
        /// Gets or sets the discount card number.
        /// </summary>
        /// <value>The discount card number.</value>
        [JsonProperty("discountCardNumber")]
        public string DiscountCardNumber { get; set; }

        /// <summary>
        /// Gets or sets the sales amount.
        /// </summary>
        /// <value>The sales amount.</value>
        [JsonProperty("salesAmount")]
        public double? SalesAmount { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        [JsonProperty("state")]
        public State State { get; set; }

        /// <summary>
        /// Gets or sets the attribute values.
        /// </summary>
        /// <value>The attribute values.</value>
        [JsonProperty("attributes")]
        public AttributeValue[] Attributes { get; set; }

        /// <summary>
        /// Gets or sets the price type.
        /// </summary>
        /// <value>The price type.</value>
        [JsonProperty("priceType")]
        public PriceType PriceType { get; set; }

        /// <summary>
        /// Gets or sets the bonus program.
        /// </summary>
        /// <value>The bonus program.</value>
        [JsonProperty("bonusProgram")]
        public BonusProgram BonusProgram { get; set; }

        /// <summary>
        /// Gets or sets the bonus points.
        /// </summary>
        /// <value>The bonus points.</value>
        [JsonProperty("bonusPoints")]
        public long? BonusPoints { get; set; }
            
        #endregion

        #region Details

        /// <summary>
        /// Gets or sets the legal title.
        /// </summary>
        /// <value>The legal title.</value>
        [JsonProperty("legalTitle")]
        public string LegalTitle { get; set; }

        /// <summary>
        /// Gets or sets the legal address.
        /// </summary>
        /// <value>The legal address.</value>
        [JsonProperty("legalAddress")]
        public string LegalAddress { get; set; }

        /// <summary>
        /// Gets or sets the legal address full.
        /// </summary>
        /// <value>The legal address full.</value>
        [JsonProperty("legalAddressFull")]
        public Address LegalAddressFull { get; set; }

        /// <summary>
        /// Gets or sets the inn.
        /// </summary>
        /// <value>The inn.</value>
        [JsonProperty("inn")]
        public string Inn { get; set; }

        /// <summary>
        /// Gets or sets the kpp.
        /// </summary>
        /// <value>The kpp.</value>
        [JsonProperty("kpp")]
        public string Kpp { get; set; }

        /// <summary>
        /// Gets or sets the ogrn.
        /// </summary>
        /// <value>The ogrn.</value>
        [JsonProperty("ogrn")]
        public string Ogrn { get; set; }

        /// <summary>
        /// Gets or sets the ogrnip.
        /// </summary>
        /// <value>The ogrnip.</value>
        [JsonProperty("ogrnip")]
        public string Ogrnip { get; set; }

        /// <summary>
        /// Gets or sets the okpo.
        /// </summary>
        /// <value>The okpo.</value>
        [JsonProperty("okpo")]
        public string Okpo { get; set; }

        /// <summary>
        /// Gets or sets the certificate number.
        /// </summary>
        /// <value>The certificate number.</value>
        [JsonProperty("certificateNumber")]
        public string CertificateNumber { get; set; }

        /// <summary>
        /// Gets or sets the certificate date.
        /// </summary>
        /// <value>The certificate date.</value>
        [JsonProperty("certificateDate")]
        public DateTime? CertificateDate { get; set; }

        /// <summary>
        /// Gets or sets the accounts.
        /// </summary>
        /// <value>The accounts.</value>
        [JsonProperty("accounts")]
        public PagedMetaEntities<AgentAccount> Accounts { get; set; }

        /// <summary>
        /// Gets or sets the contact persons.
        /// </summary>
        /// <value>The contact persons.</value>
        [JsonProperty("contactpersons")]
        public PagedMetaEntities<ContactPerson> ContactPersons { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>The tags.</value>
        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        /// <summary>
        /// Gets or sets the discounts.
        /// </summary>
        /// <value>The discounts.</value>
        [JsonProperty("discounts")]
        public DiscountData[] DiscountData { get; set; }
            
        #endregion
            
        #endregion
    }
}