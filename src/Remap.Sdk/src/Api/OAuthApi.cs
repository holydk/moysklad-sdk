using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Models;
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
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public OAuthApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/security/token", httpClient, credentials)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Gets the access token by credentials from the API configuration.
        /// </summary>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="GetTokenResponse"/>.</returns>
        public virtual Task<ApiResponse<GetTokenResponse>> GetAsync() => CallAsync<GetTokenResponse>(new RequestContext(HttpMethod.Post));

        #endregion Methods
    }
}