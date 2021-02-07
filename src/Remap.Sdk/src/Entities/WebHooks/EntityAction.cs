using System.Runtime.Serialization;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an entity action.
    /// </summary>
    public enum EntityAction
    {
        /// <summary>
        /// Create entity action.
        /// </summary>
        [EnumMember(Value = "CREATE")]
        Create,

        /// <summary>
        /// Update entity action.
        /// </summary>
        [EnumMember(Value = "UPDATE")]
        Update,

        /// <summary>
        /// Delete entity action.
        /// </summary>
        [EnumMember(Value = "DELETE")]
        Delete
    }
}