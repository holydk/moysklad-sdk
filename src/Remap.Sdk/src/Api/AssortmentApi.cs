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
        /// with the base API path.
        /// </summary>
        /// <param name="basePath">The API base path.</param>
        public AssortmentApi(string basePath)
            : base(basePath, "/api/remap/1.2/entity/assortment")
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="AssortmentApi" /> class
        /// with the API configuration.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        public AssortmentApi(Configuration configuration = null)
            : base("/api/remap/1.2/entity/assortment", configuration)
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