using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Extensions;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the image endpoint.
    /// </summary>
    public class ImageApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ImageApi" /> class
        /// with the relative path, MoySklad credentials factory if specified and the HTTP client factory if specified (or use default).
        /// </summary>
        /// <param name="relativePath">The relative path.</param>
        /// <param name="credentialsFactory">The factory to create the MoySklad credentials.</param>
        /// <param name="httpClientFactory">The factory to create the HTTP client.</param>
        public ImageApi(string relativePath, Func<MoySkladCredentials> credentialsFactory = null, Func<HttpClient> httpClientFactory = null)
            : base(relativePath, credentialsFactory, httpClientFactory)
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

            var requestContext = new RequestContext($"{Path}/{request.EntityId}/images")
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
            var requestContext = new RequestContext(downloadHref);

            return CallAsync<byte[]>(requestContext);
        }

        #endregion
    }
}
