using System;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using RestSharp;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the product folder endpoint.
    /// </summary>
    public class ProductFolderApi : ApiAccessorBase
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ProductFolderApi" /> class
        /// with the base API path.
        /// </summary>
        /// <param name="basePath">The API base path.</param>
        public ProductFolderApi(string basePath)
            : base(basePath, "/api/remap/1.2/entity/productfolder")
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ProductFolderApi" /> class
        /// with the API configuration.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        public ProductFolderApi(Configuration configuration = null)
            : base("/api/remap/1.2/entity/productfolder", configuration)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the product folders.
        /// </summary>
        /// <param name="request">The product folders request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="GetProductFoldersResponse"/>.</returns>
        public virtual Task<ApiResponse<GetProductFoldersResponse>> GetAllAsync(GetProductFoldersRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var requestContext = PrepareRequestContext().WithQuery(request.Query.Build());
            return CallAsync<GetProductFoldersResponse>(requestContext);
        }

        /// <summary>
        /// Gets the product folder.
        /// </summary>
        /// <param name="request">The product folder request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="ProductFolder"/>.</returns>
        public virtual Task<ApiResponse<ProductFolder>> GetAsync(GetProductFolderRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            
            var requestContext = PrepareRequestContext(path: $"{Path}/{request.Id}")
                .WithQuery(request.Query.Build());
            return CallAsync<ProductFolder>(requestContext);
        }

        /// <summary>
        /// Updates the product folder.
        /// </summary>
        /// <param name="productFolder">The product folder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="ProductFolder"/>.</returns>
        public virtual Task<ApiResponse<ProductFolder>> UpdateAsync(ProductFolder productFolder)
        {
            if (productFolder == null)
                throw new ArgumentNullException(nameof(productFolder));

            var requestContext = PrepareRequestContext(method: Method.PUT, path: $"{Path}/{productFolder.Id}")
                .WithBody(Serialize(productFolder));
            return CallAsync<ProductFolder>(requestContext);
        }
            
        #endregion
    }
}