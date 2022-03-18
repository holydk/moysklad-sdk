using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the assortment endpoint.
    /// </summary>
    public class AssortmentApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="AssortmentApi" /> class
        /// with MoySklad credentials factory if specified and the HTTP client factory if specified (or use default).
        /// </summary>
        /// <param name="credentialsFactory">The factory to create the MoySklad credentials.</param>
        /// <param name="httpClientFactory">The factory to create the HTTP client.</param>
        public AssortmentApi(Func<MoySkladCredentials> credentialsFactory = null, Func<HttpClient> httpClientFactory = null)
            : base("/api/remap/1.2/entity/assortment", credentialsFactory, httpClientFactory)
        {
        }
            
        #endregion

        #region Methods

        /// <summary>
        /// Gets the assortment.
        /// </summary>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="EntitiesResponse{Assortment}"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<Assortment>>> GetAllAsync(AssortmentApiParameterBuilder query = null) => GetAsync<EntitiesResponse<Assortment>>(query);
            
        #endregion
    }
}