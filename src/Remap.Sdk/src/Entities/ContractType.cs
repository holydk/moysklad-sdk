using System.Runtime.Serialization;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an reward type.
    /// </summary>
    public enum ContractType
    {
        /// <summary>
        /// Contract of commission.
        /// </summary>
        [EnumMember(Value = "Commission")]
        Commission,

        /// <summary>
        /// Contract of sale.
        /// </summary>
        [EnumMember(Value = "Sales")]
        Sales,
    }
}