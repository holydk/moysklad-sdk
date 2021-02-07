using System;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using RestSharp;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the variant endpoint.
    /// </summary>
    public class VariantApi : ApiAccessorBase
    {
        #region Properties

        /// <summary>
        /// Gets the API to interact with the metadata endpoint. 
        /// </summary>
        public virtual MetadataApi<VariantMetadata> Metadata { get; }

        /// <summary>
        /// Gets the API to interact with the image endpoint. 
        /// </summary>
        public virtual ImageApi Images { get; }

        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="VariantApi" /> class
        /// with the base API path.
        /// </summary>
        /// <param name="basePath">The API base path.</param>
        public VariantApi(string basePath)
            : base(basePath, "/api/remap/1.2/entity/variant")
        {
            Metadata = new MetadataApi<VariantMetadata>(basePath, Path);
            Images = new ImageApi(basePath, Path);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="VariantApi" /> class
        /// with the API configuration.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        public VariantApi(Configuration configuration = null)
            : base("/api/remap/1.2/entity/variant", configuration)
        {
            Metadata = new MetadataApi<VariantMetadata>(Path, configuration);
            Images = new ImageApi(Path, configuration);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the variants.
        /// </summary>
        /// <param name="request">The variants request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="GetProductFoldersResponse"/>.</returns>
        public virtual Task<ApiResponse<GetVariantsResponse>> GetAllAsync(GetVariantsRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var requestContext = PrepareRequestContext().WithQuery(request.Query.Build());
            return CallAsync<GetVariantsResponse>(requestContext);
        }

        /// <summary>
        /// Gets the variant by id.
        /// </summary>
        /// <param name="request">The variant request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Variant"/>.</returns>
        public virtual Task<ApiResponse<Variant>> GetAsync(GetVariantRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var requestContext = PrepareRequestContext(path: $"{Path}/{request.Id}")
                .WithQuery(request.Query.Build());
            return CallAsync<Variant>(requestContext);
        }

        /// <summary>
        /// Updates the variant.
        /// </summary>
        /// <param name="variant">The variant.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Variant"/>.</returns>
        public virtual Task<ApiResponse<Variant>> UpdateAsync(Variant variant)
        {
            if (variant == null)
                throw new ArgumentNullException(nameof(variant));

            var requestContext = PrepareRequestContext(method: Method.PUT, path: $"{Path}/{variant.Id}")
                .WithBody(Serialize(variant));
            return CallAsync<Variant>(requestContext);
        }
            
        #endregion
    }
}