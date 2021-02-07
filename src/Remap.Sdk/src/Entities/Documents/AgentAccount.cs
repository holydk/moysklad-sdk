using System;
using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an agent account.
    /// </summary>
    public class AgentAccount : MetaEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the date when the entity has been updated.
        /// </summary>
        /// <value>The date when the entity has been updated.</value>
        [JsonProperty("updated")]
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the account is default.
        /// </summary>
        /// <value>The value indicating whether to the account is default.</value>
        [JsonProperty("isDefault")]
        public bool? IsDefault { get; set; }

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>The account number.</value>
        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the bank name.
        /// </summary>
        /// <value>The bank name.</value>
        [JsonProperty("bankName")]
        public string BankName { get; set; }

        /// <summary>
        /// Gets or sets the bank location.
        /// </summary>
        /// <value>The bank location.</value>
        [JsonProperty("bankLocation")]
        public string BankLocation { get; set; }

        /// <summary>
        /// Gets or sets the correspondent account.
        /// </summary>
        /// <value>The correspondent account.</value>
        [JsonProperty("correspondentAccount")]
        public string CorrespondentAccount { get; set; }

        /// <summary>
        /// Gets or sets the bic.
        /// </summary>
        /// <value>The bic.</value>
        [JsonProperty("bic")]
        public string Bic { get; set; }
            
        #endregion
    }
}