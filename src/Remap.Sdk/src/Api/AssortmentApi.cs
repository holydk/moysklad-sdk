using System;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Models;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the assortment endpoint.
    /// </summary>
    public class AssortmentApi : ApiAccessorBase
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="AssortmentApi" /> class
        /// with the API configuration is specified (or use <see cref="Configuration.Default" />) and base API path.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        /// <param name="basePath">The API base path.</param>
        public AssortmentApi(Configuration configuration = null, string basePath = null)
            : base("/api/remap/1.2/entity/assortment", basePath, configuration)
        {
        }
            
        #endregion

        #region Methods

        /// <summary>
        /// Gets the assortment.
        /// </summary>
        /// <param name="request">The assortment request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="GetAssortmentResponse"/>.</returns>
        public virtual Task<ApiResponse<GetAssortmentResponse>> GetAllAsync(GetAssortmentRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            
            var requestContext = PrepareRequestContext().WithQuery(request.Query.Build()); 
            return CallAsync<GetAssortmentResponse>(requestContext);
        }
            
        #endregion
    }
}