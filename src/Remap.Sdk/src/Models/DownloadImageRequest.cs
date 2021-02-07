using System;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents a request to get image data.
    /// </summary>
    public class DownloadImageRequest
    {
        #region Properties

        /// <summary>
        /// Gets or sets the metadata about image.
        /// </summary>
        /// <value>The metadata about image.</value>
        public Image Image { get; set; }

        /// <summary>
        /// Gets or sets the image type. (Defaults to Normal.)
        /// </summary>
        /// <value>The image type.</value>
        public ImageType ImageType { get; set; }
            
        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="DownloadImageRequest" /> class
        /// with the image and the image type.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="imageType">The image type.</param>
        public DownloadImageRequest(Image image, ImageType imageType = ImageType.Normal)
        {
            Image = image ?? throw new ArgumentNullException(nameof(image));
            ImageType = imageType;
        }
            
        #endregion
    }
}