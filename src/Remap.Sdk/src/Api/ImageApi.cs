using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Extensions;
using Confiti.MoySklad.Remap.Models;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the <see cref="Image"/> endpoint.
    /// </summary>
    public class ImageApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ImageApi" /> class
        /// with the API endpoint relative path, the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="relativePath">The API endpoint relative path.</param>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public ImageApi(string relativePath, HttpClient httpClient, MoySkladCredentials credentials)
            : base(relativePath, httpClient, credentials)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Downloads the image.
        /// </summary>
        /// <param name="image">The image to download.</param>
        /// <param name="imageType">The image type.</param>
        /// <returns>The <see cref="Task"/> containing the API response with image data.</returns>
        public virtual Task<ApiResponse<Stream>> DownloadAsync(Image image, ImageType imageType = ImageType.Normal)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            var downloadHref = image.GetDownloadHref(imageType);
            var requestContext = new RequestContext(downloadHref);

            return CallAsync<Stream>(requestContext);
        }

        /// <summary>
        /// Gets the images.
        /// </summary>
        /// <param name="entityId">The id to get images of entity.</param>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="EntitiesResponse{Image}"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<Image>>> GetAllAsync(Guid entityId, ApiParameterBuilder<Image> query = null)
        {
            var requestContext = new RequestContext($"{Path}/{entityId.ToString()}/images");

            if (query != null)
                requestContext.WithQuery(query.Build());

            return CallAsync<EntitiesResponse<Image>>(requestContext);
        }

        #endregion Methods
    }
}