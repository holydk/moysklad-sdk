using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the token endpoint.
    /// </summary>
    public class OAuthApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="OAuthApi" /> class
        /// with MoySklad credentials factory if specified and the HTTP client factory if specified (or use default).
        /// </summary>
        /// <param name="credentialsFactory">The factory to create the MoySklad credentials.</param>
        /// <param name="httpClientFactory">The factory to create the HTTP client.</param>
        public OAuthApi(Func<MoySkladCredentials> credentialsFactory = null, Func<HttpClient> httpClientFactory = null)
            : base("/api/remap/1.2/security/token", credentialsFactory, httpClientFactory)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the access token by credentials from the API configuration.
        /// </summary>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="GetTokenResponse"/>.</returns>
        public virtual Task<ApiResponse<GetTokenResponse>> GetAsync()
        {
            var requestContext = new RequestContext(HttpMethod.Post);
            return CallAsync<GetTokenResponse>(requestContext);
        }

        #endregion
    }
}