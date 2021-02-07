using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an supply position.
    /// </summary>
    public class SupplyPosition : DocumentPosition
    {
        //private DocumentEntity.Gtd gtd;
        //private List<String> things;
        //private List<TrackingCode> trackingCodes;

        #region Properties

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        [JsonProperty("country")]
        public Country Country { get; set; }

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
        /// Gets or sets the overhead.
        /// </summary>
        /// <value>The overhead.</value>
        [JsonProperty("overhead")]
        public long? Overhead { get; set; }

        #endregion
    }
}
