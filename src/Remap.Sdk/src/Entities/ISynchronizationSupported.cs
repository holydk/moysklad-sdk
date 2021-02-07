namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an object which supports synchronization.
    /// </summary>
    public interface ISynchronizationSupported
    {
        /// <summary>
        /// Gets or sets the synchronization id.
        /// </summary>
        /// <value>The synchronization id.</value>
        string SyncId { get; set; }
    }
}