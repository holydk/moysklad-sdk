using System;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents the image (e.g. product, variant).
    /// </summary>
    public class Image : MetaEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the filename.
        /// </summary>
        /// <value>The filename.</value>
        public string Filename { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public byte[] Content { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        public int Size { get; set; }

        /// <summary>
        /// Gets or sets the updated time.
        /// </summary>
        /// <value>The updated time.</value>
        public DateTime Updated { get; set; }

        /// <summary>
        /// Gets or sets the miniature metadata.
        /// </summary>
        /// <value>The miniature metadata.</value>
        public Meta Miniature { get; set; }

        /// <summary>
        /// Gets or sets the tiny metadata.
        /// </summary>
        /// <value>The tiny metadata.</value>
        public Meta Tiny { get; set; }
            
        #endregion
    }
}