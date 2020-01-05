using System.Threading.Tasks;
using Confetti.MoySklad.Remap.Client;
using Confetti.MoySklad.Remap.Models;
using RestSharp;

namespace Confetti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the token endpoint.
    /// </summary>
    public class OAuthApi : ApiAccessorBase
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="OAuthApi" /> class
        /// with the base API path.
        /// </summary>
        /// <param name="basePath">The API base path.</param>
        public OAuthApi(string basePath)
            : base(basePath, "/api/remap/1.2/security/token")
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="OAuthApi" /> class
        /// with the API configuration.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        public OAuthApi(Configuration configuration = null)
            : base("/api/remap/1.2/security/token", configuration)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the access token by credentials from the API configuration.
        /// </summary>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="GetTokenResponse"/>.</returns>
        public virtual async Task<ApiResponse<GetTokenResponse>> GetTokenAsync()
        {
            UseAuthentication("Basic");
            
            var requestContext = PrepareRequestContext(method: Method.POST); 
            return await CallAsync<GetTokenResponse>(requestContext);
        }

        #endregion
    }
}