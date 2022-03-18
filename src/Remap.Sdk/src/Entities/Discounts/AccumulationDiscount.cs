namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an accumulation discount.
    /// </summary>
    public class AccumulationDiscount : GoodDiscount
    {
        #region Properties

        /// <summary>
        /// Gets or sets the levels.
        /// </summary>
        /// <value>The levels.</value>
        public AccumulationDiscountLevel[] Levels { get; set; }
            
        #endregion
    }
}