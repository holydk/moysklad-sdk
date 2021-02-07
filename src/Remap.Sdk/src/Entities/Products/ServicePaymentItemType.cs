using System.Runtime.Serialization;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an payment item type of the service.
    /// </summary>
    public enum ServicePaymentItemType
    {
        /// <summary>
        /// Service payment item type.
        /// </summary>
        [EnumMember(Value = "SERVICE")]
        Service,

        /// <summary>
        /// Work payment item type.
        /// </summary>
        [EnumMember(Value = "WORK")]
        Work,

        /// <summary>
        /// Providing RID payment item type.
        /// </summary>
        [EnumMember(Value = "PROVIDING_RID")]
        ProvidingRID,

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