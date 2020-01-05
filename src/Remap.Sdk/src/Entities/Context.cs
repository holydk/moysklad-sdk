using Newtonsoft.Json;

namespace Confetti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an context about employee.
    /// </summary>
    public class Context
    {
        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>The employee.</value>
        [JsonProperty("employee", Required = Required.Always)]
        public Employee Employee { get; set; }
    }
}