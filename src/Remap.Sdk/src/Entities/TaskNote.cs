using System;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an task note.
    /// </summary>
    public class TaskNote : MetaEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>The author.</value>
        public Employee Author { get; set; }

        /// <summary>
        /// Gets or sets the date when the note has been created.
        /// </summary>
        /// <value>The date when the note has been created.</value>
        public DateTime? Moment { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }

        #endregion
    }
}