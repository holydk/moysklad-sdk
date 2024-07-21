using System.Net.Http;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Queries;

namespace Confiti.MoySklad.Remap.Api
{
    /// <inheritdoc/>
    public class SupplyApi : EntityApiAccessor<Supply, ApiParameterBuilder<SupplyQuery>, ApiParameterBuilder<SupplyQuery>>
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="SupplyApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public SupplyApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/supply", httpClient, credentials)
        {
        }

        #endregion Ctor
    }
}