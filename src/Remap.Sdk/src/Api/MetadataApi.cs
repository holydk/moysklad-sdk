using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the metadata endpoint.
    /// </summary>
    /// <typeparam name="TResponse">The metadata type.</typeparam>
    public class MetadataApi<TResponse> : ApiAccessorBase where TResponse : MetaEntity
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="MetadataApi{TResponse}" /> class
        /// with the relative path, base API path 
        /// and API configuration is specified (or use <see cref="Configuration.Default" />).
        /// </summary>
        /// <param name="relativePath">The relative path.</param>
        /// <param name="basePath">The API base path.</param>
        /// <param name="configuration">The API configuration.</param>
        public MetadataApi(string relativePath, string basePath = null, Configuration configuration = null)
            : base($"{relativePath}/metadata", basePath, configuration)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the metadata.
        /// </summary>
        /// <returns>The <see cref="Task"/> containing the API response with metadata.</returns>
        public virtual Task<ApiResponse<TResponse>> GetAsync()
        {
            var requestContext = PrepareRequestContext();
            return CallAsync<TResponse>(requestContext);
        }

        #endregion
    }

    /// <summary>
    /// Represents the API to interact with the metadata endpoint.
    /// </summary>
    /// <typeparam name="TResponse">The metadata type.</typeparam>
    /// <typeparam name="TQuery">The concrete type of the meta entity query.</typeparam>
    public class MetadataApi<TResponse, TQuery> : MetadataApi<TResponse> where TResponse : MetaEntity where TQuery : class
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="MetadataApi{TResponse, TQuery}" /> class
        /// with the relative path, base API path 
        /// and API configuration is specified (or use <see cref="Configuration.Default" />).
        /// </summary>
        /// <param name="relativePath">The relative path.</param>
        /// <param name="basePath">The API base path.</param>
        /// <param name="configuration">The API configuration.</param>
        public MetadataApi(string relativePath, string basePath = null, Configuration configuration = null)
            : base(relativePath, basePath, configuration)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the metadata.
        /// </summary>
        /// <param name="query">The meta entity query.</param>
        /// <returns>The <see cref="Task"/> containing the API response with metadata.</returns>
        public virtual Task<ApiResponse<TResponse>> GetAsync(ApiParameterBuilder<TQuery> query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var requestContext = PrepareRequestContext().WithQuery(query.Build());
            return CallAsync<TResponse>(requestContext);
        }

        #endregion
    }
}
