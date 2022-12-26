using Newtonsoft.Json;
using System;

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
        /// Gets or sets the actual address.
        /// </summary>
        /// <value>The actual address.</value>
        public string ActualAddress { get; set; }

        /// <summary>
        /// Gets or sets the actual address full.
        /// </summary>
        /// <value>The actual address full.</value>
        public Address ActualAddressFull { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is archived.
        /// </summary>
        /// <value>The value indicating whether to the entity is archived.</value>
        public bool? Archived { get; set; }

        /// <summary>
        /// Gets or sets the attribute values.
        /// </summary>
        /// <value>The attribute values.</value>
        public AttributeValue[] Attributes { get; set; }

        /// <summary>
        /// Gets or sets the bonus points.
        /// </summary>
        /// <value>The bonus points.</value>
        public long? BonusPoints { get; set; }

        /// <summary>
        /// Gets or sets the bonus program.
        /// </summary>
        /// <value>The bonus program.</value>
        public BonusProgram BonusProgram { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the company type.
        /// </summary>
        /// <value>The company type.</value>
        public CompanyType? CompanyType { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the discount card number.
        /// </summary>
        /// <value>The discount card number.</value>
        public string DiscountCardNumber { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the external code.
        /// </summary>
        /// <value>The external code.</value>
        public string ExternalCode { get; set; }

        /// <summary>
        /// Gets or sets the fax.
        /// </summary>
        /// <value>The fax.</value>
        public string Fax { get; set; }

        /// <summary>
        /// Gets or sets the group.
        /// </summary>
        /// <value>The group.</value>
        public Group Group { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        public PagedEntities<CounterpartyNote> Notes { get; set; }

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>The owner.</value>
        public Employee Owner { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the price type.
        /// </summary>
        /// <value>The price type.</value>
        public PriceType PriceType { get; set; }

        /// <summary>
        /// Gets or sets the sales amount.
        /// </summary>
        /// <value>The sales amount.</value>
        public double? SalesAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is shared.
        /// </summary>
        /// <value>The value indicating whether to the entity is shared.</value>
        public bool? Shared { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public State State { get; set; }

        /// <summary>
        /// Gets or sets the synchronization id.
        /// </summary>
        /// <value>The synchronization id.</value>
        public string SyncId { get; set; }

        /// <summary>
        /// Gets or sets the date when the entity has been updated.
        /// </summary>
        /// <value>The date when the entity has been updated.</value>
        public DateTime? Updated { get; set; }

        #endregion Common

        #region Details

        /// <summary>
        /// Gets or sets the accounts.
        /// </summary>
        /// <value>The accounts.</value>
        public PagedEntities<AgentAccount> Accounts { get; set; }

        /// <summary>
        /// Gets or sets the certificate date.
        /// </summary>
        /// <value>The certificate date.</value>
        public DateTime? CertificateDate { get; set; }

        /// <summary>
        /// Gets or sets the certificate number.
        /// </summary>
        /// <value>The certificate number.</value>
        public string CertificateNumber { get; set; }

        /// <summary>
        /// Gets or sets the contact persons.
        /// </summary>
        /// <value>The contact persons.</value>
        [JsonProperty("contactpersons")]
        public PagedEntities<ContactPerson> ContactPersons { get; set; }

        /// <summary>
        /// Gets or sets the discounts.
        /// </summary>
        /// <value>The discounts.</value>
        public DiscountData[] Discounts { get; set; }

        /// <summary>
        /// Gets or sets the inn.
        /// </summary>
        /// <value>The inn.</value>
        public string Inn { get; set; }

        /// <summary>
        /// Gets or sets the kpp.
        /// </summary>
        /// <value>The kpp.</value>
        public string Kpp { get; set; }

        /// <summary>
        /// Gets or sets the legal address.
        /// </summary>
        /// <value>The legal address.</value>
        public string LegalAddress { get; set; }

        /// <summary>
        /// Gets or sets the legal address full.
        /// </summary>
        /// <value>The legal address full.</value>
        public Address LegalAddressFull { get; set; }

        /// <summary>
        /// Gets or sets the legal title.
        /// </summary>
        /// <value>The legal title.</value>
        public string LegalTitle { get; set; }

        /// <summary>
        /// Gets or sets the ogrn.
        /// </summary>
        /// <value>The ogrn.</value>
        public string Ogrn { get; set; }

        /// <summary>
        /// Gets or sets the ogrnip.
        /// </summary>
        /// <value>The ogrnip.</value>
        public string Ogrnip { get; set; }

        /// <summary>
        /// Gets or sets the okpo.
        /// </summary>
        /// <value>The okpo.</value>
        public string Okpo { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>The tags.</value>
        public string[] Tags { get; set; }

        #endregion Details

        #endregion Properties
    }
}