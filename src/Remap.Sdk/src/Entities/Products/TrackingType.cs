using System.Runtime.Serialization;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an tracking type.
    /// </summary>
    public enum TrackingType
    {
        /// <summary>
        /// Not tracked.
        /// </summary>
        [EnumMember(Value = "NOT_TRACKED")]
        NotTracked,

        /// <summary>
        /// Tobacco tracking type.
        /// </summary>
        [EnumMember(Value = "TOBACCO")]
        Tobacco,

        /// <summary>
        /// Shoes tracking type.
        /// </summary>
        [EnumMember(Value = "SHOES")]
        Shoes,

        /// <summary>
        /// Clothes tracking type.
        /// </summary>
        [EnumMember(Value = "LP_CLOTHES")]
        Clothes,

        /// <summary>
        /// Linens tracking type.
        /// </summary>
        [EnumMember(Value = "LP_LINENS")]
        Linens,

        /// <summary>
        /// Perfumery tracking type.
        /// </summary>
        [EnumMember(Value = "PERFUMERY")]
        Perfumery,

        /// <summary>
        /// Electronics tracking type.
        /// </summary>
        [EnumMember(Value = "ELECTRONICS")]
        Electronics,

        /// <summary>
        /// Tires tracking type.
        /// </summary>
        [EnumMember(Value = "TIRES")]
        Tires,

        /// <summary>
        /// Tracking type for alternative tobacco products.
        /// </summary>
        [EnumMember(Value = "OTP")]
        Otp,
    }
}