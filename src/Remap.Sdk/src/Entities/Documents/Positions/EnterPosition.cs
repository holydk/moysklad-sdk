namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an enter position.
    /// </summary>
    public class EnterPosition : DocumentPosition
    {
        // todo
        //private DocumentEntity.Gtd gtd;
        //private List<String> things;

        #region Properties

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        public Country Country { get; set; }

        /// <summary>
        /// Gets or sets the overhead.
        /// </summary>
        /// <value>The overhead.</value>
        public long? Overhead { get; set; }

        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        /// <value>The reason.</value>
        public string Reason { get; set; }

        #endregion Properties
    }
}