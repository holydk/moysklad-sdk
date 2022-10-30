using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System.Net.Http;

namespace Confiti.MoySklad.Remap.Api
{
    /// <inheritdoc/>
    public class SalesReturnApi : EntityApiAccessor<SalesReturn, ApiParameterBuilder<SalesReturnQuery>, ApiParameterBuilder<SalesReturnQuery>>
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="SalesReturnApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public SalesReturnApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/salesreturn", httpClient, credentials)
        {
        }

        #endregion Ctor
    }
}