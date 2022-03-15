using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the metadata endpoint.
    /// </summary>
    /// <typeparam name="TResponse">The metadata type.</typeparam>
    public class MetadataApi<TResponse> : ApiAccessor where TResponse : MetaEntity
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="MetadataApi{TResponse}" /> class
        /// with the relative path, MoySklad credentials if specified and the HTTP client if specified (or use default).
        /// </summary>
        /// <param name="relativePath">The relative path.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public MetadataApi(string relativePath, MoySkladCredentials credentials = null, HttpClient httpClient = null)
            : base($"{relativePath}/metadata", credentials, httpClient)
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
            return CallAsync<TResponse>(new RequestContext());
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
        /// with the relative path, MoySklad credentials if specified and the HTTP client if specified (or use default).
        /// </summary>
        /// <param name="relativePath">The relative path.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public MetadataApi(string relativePath, MoySkladCredentials credentials = null, HttpClient httpClient = null)
            : base(relativePath, credentials, httpClient)
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

            var requestContext = new RequestContext()
                .WithQuery(query.Build());
                
            return CallAsync<TResponse>(requestContext);
        }

        #endregion
    }
}
