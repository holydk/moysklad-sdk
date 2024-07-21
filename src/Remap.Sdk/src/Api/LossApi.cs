using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Queries;
using System.Net.Http;

namespace Confiti.MoySklad.Remap.Api
{
    /// <inheritdoc/>
    public class LossApi : EntityApiAccessor<Loss, ApiParameterBuilder<LossQuery>, ApiParameterBuilder<LossQuery>>
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="LossApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public LossApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/loss", httpClient, credentials)
        {
        }

        #endregion Ctor
    }
}