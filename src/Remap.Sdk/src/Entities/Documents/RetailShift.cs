using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
	/// <summary>
	/// Represents an retail shift.
	/// </summary>
	public class RetailShift : MetaEntity
	{
		#region Properties

		/// <summary>
		/// Gets or sets the attribute values.
		/// </summary>
		/// <value>The attribute values.</value>
		public AttributeValue[] Attributes { get; set; }

		/// <summary>
		/// Gets or sets the bank commission sum.
		/// </summary>
		/// <value>The bank commission sum.</value>
		public long? BankComission { get; set; }

		/// <summary>
		/// Gets or sets the bank commission percent.
		/// </summary>
		/// <value>The bank commission percent.</value>
		public decimal? BankPercent { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>The description.</value>
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the external code.
		/// </summary>
		/// <value>The external code.</value>
		public string ExternalCode { get; set; }

		/// <summary>
		/// Gets or sets the group.
		/// </summary>
		/// <value>The group.</value>
		public Group Group { get; set; }

		/// <summary>
		/// Gets or sets the date when the shift has been closed.
		/// </summary>
		/// <value>The date when the shift has been closed.</value>
		public DateTime? CloseDate { get; set; }

		/// <summary>
		/// Gets or sets the date when the shift has been created.
		/// </summary>
		/// <value>The date when the shift has been created.</value>
		public DateTime? Created { get; set; }

		/// <summary>
		/// Gets or sets the date when the shift has been deleted.
		/// </summary>
		/// <value>The date when the shift has been deleted.</value>
		public DateTime? Deleted { get; set; }

		/// <summary>
		/// Gets or sets the date when the shift has been placed.
		/// </summary>
		/// <value>The date when the shift has been placed.</value>
		public DateTime? Moment { get; set; }

		/// <summary>
		/// Gets or sets the operations.
		/// </summary>
		/// <value>The operations.</value>
		public Operation[] Operations { get; set; }

		/// <summary>
		/// Gets or sets the organization.
		/// </summary>
		/// <value>The organization.</value>
		public Organization Organization { get; set; }

		/// <summary>
		/// Gets or sets the owner.
		/// </summary>
		/// <value>The owner.</value>
		[DefaultValue("{}")]
		[JsonProperty(NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Employee Owner { get; set; } = new Employee();

		/// <summary>
		/// Gets or sets the value indicating whether to the document has been printed.
		/// </summary>
		/// <value>The value indicating whether to the document has been printed.</value>
		public bool? Printed { get; set; }

		/// <summary>
		/// Gets or sets the proceeds cash sum.
		/// </summary>
		/// <value>The proceeds cash sum.</value>
		public long? ProceedsCash { get; set; }

		/// <summary>
		/// Gets or sets the proceeds non-cash sum.
		/// </summary>
		/// <value>The proceeds non-cash sum.</value>
		public long? ProceedsNoCash { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to the document is published.
		/// </summary>
		/// <value>The value indicating whether to the document is published.</value>
		public bool? Published { get; set; }

		/// <summary>
		/// Gets or sets the QR-code bank commission sum.
		/// </summary>
		/// <value>The QR-code bank commission sum.</value>
		public long? QrBankComission { get; set; }

		/// <summary>
		/// Gets or sets the QR-code bank commission percent.
		/// </summary>
		/// <value>The QR-code bank commission percent.</value>
		public decimal? QrBankPercent { get; set; }

		/// <summary>
		/// Gets or sets the received cash sum.
		/// </summary>
		/// <value>The received cash sum.</value>
		public long? ReceivedCash { get; set; }

		/// <summary>
		/// Gets or sets the received non-cash sum.
		/// </summary>
		/// <value>The received non-cash sum.</value>
		public long? ReceivedNoCash { get; set; }

		/// <summary>
		/// Gets or sets the retail store.
		/// </summary>
		/// <value>The retail store.</value>
		public RetailStore RetailStore { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to the entity is shared.
		/// </summary>
		/// <value>The value indicating whether to the entity is shared.</value>
		public bool? Shared { get; set; }

		/// <summary>
		/// Gets or sets the store.
		/// </summary>
		/// <value>The store.</value>
		public Store Store { get; set; }

		/// <summary>
		/// Gets or sets the synchronization id.
		/// </summary>
		/// <value>The synchronization id.</value>
		public string SyncId { get; set; }

		/// <summary>
		/// Gets or sets the date when the shift has been updated.
		/// </summary>
		/// <value>The date when the shift has been updated.</value>
		public DateTime? Updated { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to the vat is enabled.
		/// </summary>
		/// <value>The value indicating whether to the vat is enabled.</value>
		public bool? VatEnabled { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to the vat is included.
		/// </summary>
		/// <value>The value indicating whether to the vat is included.</value>
		public bool? VatIncluded { get; set; }

		#endregion Properties
	}
}