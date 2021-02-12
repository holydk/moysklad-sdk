using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Extensions;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the image endpoint.
    /// </summary>
    public class ImageApi : ApiAccessorBase
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ImageApi" /> class
        /// with the relative path, base API path 
        /// and API configuration is specified (or use <see cref="Configuration.Default" />).
        /// </summary>
        /// <param name="relativePath">The relative path.</param>
        /// <param name="basePath">The API base path.</param>
        /// <param name="configuration">The API configuration.</param>
        public ImageApi(string relativePath, string basePath = null, Configuration configuration = null)
            : base(relativePath, basePath, configuration)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the images.
        /// </summary>
        /// <param name="request">The images request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="GetImagesResponse"/>.</returns>
        public virtual Task<ApiResponse<GetImagesResponse>> GetAllAsync(GetImagesRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrWhiteSpace(request.EntityId))
                throw new ApiException(400, $"Parameter '{nameof(request.EntityId)}' is missed.");

            var requestContext = PrepareRequestContext(path: $"{Path}/{request.EntityId}/images")
                .WithQuery(request.Query.Build());
            return CallAsync<GetImagesResponse>(requestContext);
        }

        /// <summary>
        /// Downloads the image.
        /// </summary>
        /// <param name="request">The download image request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with image data.</returns>
        public virtual Task<ApiResponse<byte[]>> DownloadAsync(DownloadImageRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.Image == null)
                throw new ApiException(400, $"Parameter '{nameof(request.Image)}' is missed.");

            var downloadHref = request.Image.GetDownloadHref(request.ImageType);
            var requestContext = PrepareRequestContext(path: downloadHref);
            return CallAsync<byte[]>(requestContext);
        }

        #endregion
    }
}
