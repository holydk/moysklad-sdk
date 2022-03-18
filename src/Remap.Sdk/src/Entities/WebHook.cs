using System.Runtime.Serialization;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an web hook.
    /// </summary>
    public class WebHook : MetaEntity
    {
        /// <summary>
        /// Gets or sets the type of entity.
        /// </summary>
        /// <value>The type of entity.</value>
        public EntityType EntityType { get; set; }

        /// <summary>
        /// Gets or sets the action of entity.
        /// </summary>
        /// <value>The action of entity.</value>
        public EntityAction Action { get; set; }

        /// <summary>
        /// Gets or sets the method.
        /// </summary>
        /// <value>The method.</value>
        public HttpMethod Method { get; set; }

        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        /// <value>The url.</value>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the web hook is enabled.
        /// </summary>
        /// <value>The value indicating whether to the web hook is enabled.</value>
        public bool Enabled { get; set; }

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
}