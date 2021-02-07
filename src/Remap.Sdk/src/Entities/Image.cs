using System;
using Newtonsoft.Json;

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
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the filename.
        /// </summary>
        /// <value>The filename.</value>
        [JsonProperty("filename")]
        public string Filename { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        [JsonProperty("content")]
        public byte[] Content { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        [JsonProperty("size")]
        public int Size { get; set; }

        /// <summary>
        /// Gets or sets the updated time.
        /// </summary>
        /// <value>The updated time.</value>
        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

        /// <summary>
        /// Gets or sets the miniature metadata.
        /// </summary>
        /// <value>The miniature metadata.</value>
        [JsonProperty("miniature")]
        public Meta Miniature { get; set; }

        /// <summary>
        /// Gets or sets the tiny metadata.
        /// </summary>
        /// <value>The tiny metadata.</value>
        [JsonProperty("tiny")]
        public Meta Tiny { get; set; }
            
        #endregion
    }
}