using System;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an agent account.
    /// </summary>
    public class AgentAccount : MetaEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>The account number.</value>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the bank location.
        /// </summary>
        /// <value>The bank location.</value>
        public string BankLocation { get; set; }

        /// <summary>
        /// Gets or sets the bank name.
        /// </summary>
        /// <value>The bank name.</value>
        public string BankName { get; set; }

        /// <summary>
        /// Gets or sets the bic.
        /// </summary>
        /// <value>The bic.</value>
        public string Bic { get; set; }

        /// <summary>
        /// Gets or sets the correspondent account.
        /// </summary>
        /// <value>The correspondent account.</value>
        public string CorrespondentAccount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the account is default.
        /// </summary>
        /// <value>The value indicating whether to the account is default.</value>
        public bool? IsDefault { get; set; }

        /// <summary>
        /// Gets or sets the date when the entity has been updated.
        /// </summary>
        /// <value>The date when the entity has been updated.</value>
        public DateTime? Updated { get; set; }

        #endregion Properties
    }
}