using System.Runtime.Serialization;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an payment item type of the goods.
    /// </summary>
    public enum PhysicalGoodsPaymentItemType
    {
        /// <summary>
        /// Good payment item type.
        /// </summary>
        [EnumMember(Value = "GOOD")]
        Good,

        /// <summary>
        /// Excisable good payment item type.
        /// </summary>
        [EnumMember(Value = "EXCISABLE_GOOD")]
        ExcisableGood,

        /// <summary>
        /// Compound payment item type.
        /// </summary>
        [EnumMember(Value = "COMPOUND_PAYMENT_ITEM")]
        Compound,

        /// <summary>
        /// Another payment item type.
        /// </summary>
        [EnumMember(Value = "ANOTHER_PAYMENT_ITEM")]
        Another,
    }
}