using System.Runtime.Serialization;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an overhead distribution type
    /// </summary>
    public enum OverheadDistributionType
    {
        /// <summary>
        /// Overhead by weight.
        /// </summary>
        [EnumMember(Value = "weight")]
        Weight,

        /// <summary>
        /// Overhead by volume.
        /// </summary>
        [EnumMember(Value = "volume")]
        Volume,

        /// <summary>
        /// Overhead by price.
        /// </summary>
        [EnumMember(Value = "price")]
        Price,
    }
}
