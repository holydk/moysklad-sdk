using System.Runtime.Serialization;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an reward type.
    /// </summary>
    public enum RewardType
    {
        /// <summary>
        /// Percentage of the sale amount.
        /// </summary>
        [EnumMember(Value = "PercentOfSales")]
        PercentOfSales,

        
        /// <summary>
        /// None.
        /// </summary>
        [EnumMember(Value = "None")]
        None,
    }
}