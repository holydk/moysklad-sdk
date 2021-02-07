using System.Runtime.Serialization;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an company type.
    /// </summary>
    public enum CompanyType
    {
        /// <summary>
        /// Legal company type.
        /// </summary>
        [EnumMember(Value = "legal")]
        Legal,

        /// <summary>
        /// Entrepreneur company type.
        /// </summary>
        [EnumMember(Value = "entrepreneur")]
        Entrepreneur,

        /// <summary>
        /// Individual company type.
        /// </summary>
        [EnumMember(Value = "individual")]
        Individual
    }
}