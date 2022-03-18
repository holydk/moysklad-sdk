namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an overhead of the bundle.
    /// </summary>
    public class Overhead
    {
        #region Properties

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public long? Value { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>The currency.</value>
        public Currency Currency { get; set; }
            
        #endregion
    }
}