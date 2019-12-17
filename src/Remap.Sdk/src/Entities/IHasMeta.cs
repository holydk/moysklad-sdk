namespace Confetti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an object containing the paged metadata about entity.
    /// </summary>
    public interface IHasMeta<TMeta> where TMeta : Meta
    {
        /// <summary>
        /// Gets the metadata about entity.
        /// </summary>
        /// <value>The metadata about entity.</value>
        TMeta Meta { get; set; }
    }
}