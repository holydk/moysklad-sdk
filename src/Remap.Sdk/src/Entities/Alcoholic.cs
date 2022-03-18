namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an alcoholic product information.
    /// </summary>
    public class Alcoholic
    {
        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether to the alcoholic product contains excise stamp.
        /// </summary>
        /// <value>The value indicating whether to the alcoholic product contains excise stamp.</value>
        public bool? Excise { get; set; }

        /// <summary>
        /// Gets or sets the code of the type product.
        /// </summary>
        /// <value>The code of the type product.</value>
        public int? Type { get; set; }

        /// <summary>
        /// Gets or sets the alcoholic strength.
        /// </summary>
        /// <value>The alcoholic strength.</value>
        public double? Strength { get; set; }

        /// <summary>
        /// Gets or sets the container volume.
        /// </summary>
        /// <value>The container volume.</value>
        public double? Volume { get; set; }
            
        #endregion
    }
}