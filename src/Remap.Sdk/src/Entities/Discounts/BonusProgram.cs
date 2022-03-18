namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an bonus program.
    /// </summary>
    public class BonusProgram : Discount
    {
        #region Properties

        /// <summary>
        /// Gets or sets the earn rate roubles to point.
        /// </summary>
        /// <value>The value.</value>
        public decimal? EarnRateRoublesToPoint { get; set; }

        /// <summary>
        /// Gets or sets the spend rate points to rouble.
        /// </summary>
        /// <value>The value.</value>
        public decimal? SpendRatePointsToRouble { get; set; }

        /// <summary>
        /// Gets or sets the max paid rate percents.
        /// </summary>
        /// <value>The max paid rate percents.</value>
        public decimal? MaxPaidRatePercents { get; set; }

        /// <summary>
        /// Gets or sets the delayed bonus days.
        /// </summary>
        /// <value>The delayed bonus days.</value>
        public decimal? PostponedBonusesDelayDays { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the simultaneous accrual and withdrawal of bonuses is allowed.
        /// </summary>
        /// <value>The max paid rate percents.</value>
        public bool? EarnWhileRedeeming { get; set; }
            
        #endregion
    }
}