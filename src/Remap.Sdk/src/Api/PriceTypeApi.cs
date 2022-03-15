using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the price type endpoint.
    /// </summary>
    public class PriceTypeApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="PriceTypeApi" /> class
        /// with MoySklad credentials if specified and the HTTP client if specified (or use default).
        /// </summary>
        /// <param name="credentials">The MoySklad credentials.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public PriceTypeApi(MoySkladCredentials credentials = null, HttpClient httpClient = null)
            : base("/api/remap/1.2/context/companysettings/pricetype", credentials, httpClient)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the price types.
        /// </summary>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="PriceType"/>'s.</returns>
        public virtual Task<ApiResponse<PriceType[]>> GetAllAsync() => GetAsync<PriceType[]>();

        #endregion
    }
}
