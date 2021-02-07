namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an barcode.
    /// </summary>
    public class Barcode
    {
        #region Properties

        /// <summary>
        /// Gets or sets the barcode type.
        /// </summary>
        /// <value>The barcode type.</value>
        public BarcodeType Type { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; set; }
            
        #endregion
    }
}