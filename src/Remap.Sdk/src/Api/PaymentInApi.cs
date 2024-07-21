using System.Net.Http;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Queries;

namespace Confiti.MoySklad.Remap.Api
{
    /// <inheritdoc/>
    public class PaymentInApi : EntityApiAccessor<PaymentIn, ApiParameterBuilder, ApiParameterBuilder>
    {
        #region Properties

        /// <summary>
        /// Gets the API to interact with the metadata endpoint.
        /// </summary>
        public virtual MetadataApi<DocumentMetadata, DocumentMetadataQuery> Metadata { get; }

        #endregion Properties

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="PaymentInApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public PaymentInApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/paymentin", httpClient, credentials)
        {
            Metadata = new MetadataApi<DocumentMetadata, DocumentMetadataQuery>(Path, httpClient, credentials);
        }

        #endregion Ctor
    }
}