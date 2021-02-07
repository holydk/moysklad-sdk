using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an customer order position.
    /// </summary>
    public class CustomerOrderPosition : DocumentPosition
    {
        #region Properties

        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        /// <value>The discount.</value>
        [JsonProperty("discount")]
        public double? Discount { get; set; }

        /// <summary>
        /// Gets or sets the vat.
        /// </summary>
        /// <value>The vat.</value>
        [JsonProperty("vat")]
        public int? Vat { get; set; }

        /// <summary>
        /// Gets or sets the shipped.
        /// </summary>
        /// <value>The shipped.</value>
        [JsonProperty("shipped")]
        public double? Shipped { get; set; }

        /// <summary>
        /// Gets or sets the reserve.
        /// </summary>
        /// <value>The reserve.</value>
        [JsonProperty("reserve")]
        public double? Reserve { get; set; }

        /// <summary>
        /// Gets or sets the tax system.
        /// </summary>
        /// <value>The tax system.</value>
        [JsonProperty("taxSystem")]
        public DocumentTaxSystem? TaxSystem { get; set; }
            
        #endregion
    }
}