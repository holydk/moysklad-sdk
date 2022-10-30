using System.Runtime.Serialization;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an barcode type.
    /// </summary>
    public enum BarcodeType
    {
        /// <summary>
        /// Ean13 barcode type.
        /// </summary>
        [EnumMember(Value = "ean13")]
        Ean13,

        /// <summary>
        /// Ean8 barcode type.
        /// </summary>
        [EnumMember(Value = "ean8")]
        Ean8,

        /// <summary>
        /// Code128 barcode type.
        /// </summary>
        [EnumMember(Value = "code128")]
        Code128,

        /// <summary>
        /// Gtin barcode type.
        /// </summary>
        [EnumMember(Value = "gtin")]
        Gtin
    }
}