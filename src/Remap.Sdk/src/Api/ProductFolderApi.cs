using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the product folder endpoint.
    /// </summary>
    public class ProductFolderApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ProductFolderApi" /> class
        /// with MoySklad credentials factory if specified and the HTTP client factory if specified (or use default).
        /// </summary>
        /// <param name="credentialsFactory">The factory to create the MoySklad credentials.</param>
        /// <param name="httpClientFactory">The factory to create the HTTP client.</param>
        public ProductFolderApi(Func<MoySkladCredentials> credentialsFactory = null, Func<HttpClient> httpClientFactory = null)
            : base("/api/remap/1.2/entity/productfolder", credentialsFactory, httpClientFactory)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the product folders.
        /// </summary>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="EntitiesResponse{ProductFolder}"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<ProductFolder>>> GetAllAsync(ApiParameterBuilder<ProductFolderQuery> query = null) => GetAsync<EntitiesResponse<ProductFolder>>(query);

        /// <summary>
        /// Gets the product folder.
        /// </summary>
        /// <param name="id">The id to get the entity.</param>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="ProductFolder"/>.</returns>
        public virtual Task<ApiResponse<ProductFolder>> GetAsync(Guid id, ApiParameterBuilder<ProductFolderQuery> query = null) => GetByIdAsync<ProductFolder>(id, query);

        /// <summary>
        /// Updates the product folder.
        /// </summary>
        /// <param name="productFolder">The product folder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="ProductFolder"/>.</returns>
        public virtual Task<ApiResponse<ProductFolder>> UpdateAsync(ProductFolder productFolder) => UpdateAsync<ProductFolder>(productFolder);
            
        #endregion
    }
}