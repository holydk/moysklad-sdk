using System.Runtime.Serialization;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an attribute type.
    /// </summary>
    public enum AttributeType
    {
        #region Simple types

        /// <summary>
        /// String attribute type.
        /// </summary>
        [EnumMember(Value = "string")]
        String,

        /// <summary>
        /// Long attribute type.
        /// </summary>
        [EnumMember(Value = "long")]
        Long,

        /// <summary>
        /// Time attribute type.
        /// </summary>
        [EnumMember(Value = "time")]
        Time,

        /// <summary>
        /// File attribute type.
        /// </summary>
        [EnumMember(Value = "file")]
        File,

        /// <summary>
        /// Double attribute type.
        /// </summary>
        [EnumMember(Value = "double")]
        Double,

        /// <summary>
        /// Boolean attribute type.
        /// </summary>
        [EnumMember(Value = "boolean")]
        Boolean,

        /// <summary>
        /// Text attribute type.
        /// </summary>
        [EnumMember(Value = "text")]
        Text,

        /// <summary>
        /// Link attribute type.
        /// </summary>
        [EnumMember(Value = "link")]
        Link,
            
        #endregion

        #region Allowed entity types

        /// <summary>
        /// Custom entity attribute type.
        /// </summary>
        [EnumMember(Value = "customentity")]
        CustomEntity,

        /// <summary>
        /// Counterparty attribute type.
        /// </summary>
        [EnumMember(Value = "counterparty")]
        Counterparty,

        /// <summary>
        /// Organization attribute type.
        /// </summary>
        [EnumMember(Value = "organization")]
        Organization,

        /// <summary>
        /// Employee attribute type.
        /// </summary>
        [EnumMember(Value = "employee")]
        Employee,

        /// <summary>
        /// Product attribute type.
        /// </summary>
        [EnumMember(Value = "product")]
        Product,

        /// <summary>
        /// Bundle attribute type.
        /// </summary>
        [EnumMember(Value = "bundle")]
        Bundle,

        /// <summary>
        /// Service attribute type.
        /// </summary>
        [EnumMember(Value = "service")]
        Service,

        /// <summary>
        /// Contract attribute type.
        /// </summary>
        [EnumMember(Value = "contract")]
        Contract,

        /// <summary>
        /// Project attribute type.
        /// </summary>
        [EnumMember(Value = "project")]
        Project,

        /// <summary>
        /// Store attribute type.
        /// </summary>
        [EnumMember(Value = "store")]
        Store,
            
        #endregion
    }
}