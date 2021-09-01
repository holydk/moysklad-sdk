using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the demand endpoint.
    /// </summary>
    public class DemandApi : ApiAccessorBase
    {
        #region Properties

        /// <summary>
        /// Gets the API to interact with the metadata endpoint. 
        /// </summary>
        public virtual MetadataApi<DocumentMetadata, DocumentMetadataQuery> Metadata { get; }
            
        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="DemandApi" /> class
        /// with the API configuration is specified (or use <see cref="Configuration.Default" />) and base API path.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        /// <param name="basePath">The API base path.</param>
        public DemandApi(Configuration configuration = null, string basePath = null)
            : base("/api/remap/1.2/entity/demand", basePath, configuration)
        {
            Metadata = new MetadataApi<DocumentMetadata, DocumentMetadataQuery>(Path, basePath, configuration);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the demand.
        /// </summary>
        /// <param name="request">The demand request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Demand"/>.</returns>
        public virtual Task<ApiResponse<Demand>> GetAsync(GetDemandRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var requestContext = PrepareRequestContext(path: $"{Path}/{request.Id}")
                .WithQuery(request.Query.Build());
            return CallAsync<Demand>(requestContext);
        }

        /// <summary>
        /// Creates the demand.
        /// </summary>
        /// <param name="demand">The demand.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Demand"/>.</returns>
        public virtual Task<ApiResponse<Demand>> CreateAsync(Demand demand)
        {
            if (demand == null)
                throw new ArgumentNullException(nameof(demand));

            var requestContext = PrepareRequestContext(method: Method.POST)
                .WithBody(Serialize(demand));
            return CallAsync<Demand>(requestContext);
        }

        /// <summary>
        /// Updates the demand.
        /// </summary>
        /// <param name="demand">The demand.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Demand"/>.</returns>
        public virtual Task<ApiResponse<Demand>> UpdateAsync(Demand demand)
        {
            if (demand == null)
                throw new ArgumentNullException(nameof(demand));

            var requestContext = PrepareRequestContext(method: Method.PUT, path: $"{Path}/{demand.Id}")
                .WithBody(Serialize(demand));
            return CallAsync<Demand>(requestContext);
        }

        /// <summary>
        /// Deletes the demand.
        /// </summary>
        /// <param name="id">The demand ID.</param>
        /// <returns>The <see cref="Task"/> containing the API response.</returns>
        public virtual Task<ApiResponse> DeleteAsync(Guid id)
        {
            var requestContext = PrepareRequestContext(method: Method.DELETE, path: $"{Path}/{id}");
            return CallAsync(requestContext);
        }

        #endregion
    }
}
