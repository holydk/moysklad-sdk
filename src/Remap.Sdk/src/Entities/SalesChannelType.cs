using System.Runtime.Serialization;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an sales channel type.
    /// </summary>
    public enum SalesChannelType
    {
        /// <summary>
        /// Messenger sale channel.
        /// </summary>
        [EnumMember(Value = "MESSENGER")]
        Messenger,

        /// <summary>
        /// Social network sale channel.
        /// </summary>
        [EnumMember(Value = "SOCIAL_NETWORK")]
        SocialNetwork,

        /// <summary>
        /// Marketplace sale channel.
        /// </summary>
        [EnumMember(Value = "MARKETPLACE")]
        Marketplace,

        /// <summary>
        /// Ecommerce sale channel.
        /// </summary>
        [EnumMember(Value = "ECOMMERCE")]
        Ecommerce,

        /// <summary>
        /// Classified Ads sale channel.
        /// </summary>
        [EnumMember(Value = "CLASSIFIED_ADS")]
        ClassifiedAds,

        /// <summary>
        /// Direct sales sale channel.
        /// </summary>
        [EnumMember(Value = "DIRECT_SALES")]
        DirectSales,

        /// <summary>
        /// Other sale channel.
        /// </summary>
        [EnumMember(Value = "OTHER")]
        Other,
    }
}