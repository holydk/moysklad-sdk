using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using System.Net.Http;

namespace Confiti.MoySklad.Remap.Api
{
    /// <inheritdoc/>
    public class ServiceApi : EntityApiAccessor<Service, ApiParameterBuilder, ApiParameterBuilder>
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ServiceApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public ServiceApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/service", httpClient, credentials)
        {
        }

        #endregion Ctor
    }
}