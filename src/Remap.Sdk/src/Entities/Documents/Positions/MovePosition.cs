namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an move position.
    /// </summary>
    public class MovePosition : DocumentPosition
    {
        // todo
        //private List<String> things;

        #region Properties

        /// <summary>
        /// Gets or sets the overhead.
        /// </summary>
        /// <value>The overhead.</value>
        public long? Overhead { get; set; }

        #endregion
    }
}
