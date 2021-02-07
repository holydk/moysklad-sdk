using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the price type endpoint.
    /// </summary>
    public class PriceTypeApi : ApiAccessorBase
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="PriceTypeApi" /> class
        /// with the base API path.
        /// </summary>
        /// <param name="basePath">The API base path.</param>
        public PriceTypeApi(string basePath)
            : base(basePath, "/api/remap/1.2/context/companysettings/pricetype")
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="PriceTypeApi" /> class
        /// with the API configuration.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        public PriceTypeApi(Configuration configuration = null)
            : base("/api/remap/1.2/context/companysettings/pricetype", configuration)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the price types.
        /// </summary>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="PriceType"/>'s.</returns>
        public virtual Task<ApiResponse<PriceType[]>> GetAllAsync()
        {
            var requestContext = PrepareRequestContext();
            return CallAsync<PriceType[]>(requestContext);
        }

        #endregion
    }
}
