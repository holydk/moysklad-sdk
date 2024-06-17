using System;

namespace Confiti.MoySklad.Remap.Entities
{
	/// <summary>
	/// Represents an retail shift.
	/// </summary>
	public class RetailShift : Document
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
		/// Gets or sets the date when the shift has been closed.
		/// </summary>
		/// <value>The date when the shift has been closed.</value>
		public DateTime? CloseDate { get; set; }

		/// <summary>
		/// Gets or sets the operations.
		/// </summary>
		/// <value>The operations.</value>
		public Operation[] Operations { get; set; }

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
		/// Gets or sets the store.
		/// </summary>
		/// <value>The store.</value>
		public Store Store { get; set; }

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