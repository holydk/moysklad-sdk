using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the <see cref="PriceType"/> endpoint.
    /// </summary>
    public class PriceTypeApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="PriceTypeApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public PriceTypeApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/context/companysettings/pricetype", httpClient, credentials)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Gets the price types.
        /// </summary>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="PriceType"/>'s.</returns>
        public virtual Task<ApiResponse<PriceType[]>> GetAllAsync() => CallAsync<PriceType[]>(new RequestContext());

        #endregion Methods
    }
}