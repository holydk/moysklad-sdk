using System.Runtime.Serialization;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an state type.
    /// </summary>
    public enum StateType
    {
        /// <summary>
        /// Regular state type.
        /// </summary>
        [EnumMember(Value = "Regular")]
        Regular,

        /// <summary>
        /// Successful state type.
        /// </summary>
        [EnumMember(Value = "Successful")]
        Successful,

        /// <summary>
        /// Unsuccessful state type.
        /// </summary>
        [EnumMember(Value = "Unsuccessful")]
        Unsuccessful,
    }
}