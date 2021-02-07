using System.Runtime.Serialization;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an HTTP method.
    /// </summary>
    public enum HttpMethod
    {
        /// <summary>
        /// POST HTTP method.
        /// </summary>
        [EnumMember(Value = "POST")]
        POST
    }
}