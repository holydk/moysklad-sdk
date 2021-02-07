namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an object containing the context about employee.
    /// </summary>
    public interface IHasContext
    {
        /// <summary>
        /// Gets or sets the context about employee.
        /// </summary>
        /// <value>The context about employee.</value>
        Context Context { get; set; }
    }
}