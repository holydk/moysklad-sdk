using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an bonus program.
    /// </summary>
    public class BonusProgram : Discount
    {
        #region Properties

        /// <summary>
        /// Gets or sets the earn rate currency to point.
        /// </summary>
        /// <value>The value.</value>
        [JsonProperty("earnRateRoublesToPoint")]
        public long? EarnRateCurrencyToPoint { get; set; }

        /// <summary>
        /// Gets or sets the spend rate points to currency.
        /// </summary>
        /// <value>The value.</value>
        [JsonProperty("spendRatePointsToRouble")]
        public long? SpendRatePointsToCurrency { get; set; }

        /// <summary>
        /// Gets or sets the max paid rate percents.
        /// </summary>
        /// <value>The max paid rate percents.</value>
        [JsonProperty("maxPaidRatePercents")]
        public long? MaxPaidRatePercents { get; set; }
            
        #endregion
    }
}