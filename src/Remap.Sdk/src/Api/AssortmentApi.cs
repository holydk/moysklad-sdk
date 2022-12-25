using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the <see cref="Assortment"/> endpoint.
    /// </summary>
    public sealed class AssortmentApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="AssortmentApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public AssortmentApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/assortment", httpClient, credentials)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Gets the assortment.
        /// </summary>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="MetaEntitiesResponse{T}"/>.</returns>
        public Task<ApiResponse<MetaEntitiesResponse<Assortment>>> GetAllAsync(AssortmentApiParameterBuilder query = null)
        {
            var requestContext = new RequestContext();

            if (query != null)
                requestContext.WithQuery(query.Build());

            return CallAsync<MetaEntitiesResponse<Assortment>>(requestContext);
        }

        #endregion Methods
    }
}