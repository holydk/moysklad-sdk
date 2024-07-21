using System.Net.Http;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Queries;

namespace Confiti.MoySklad.Remap.Api
{
    /// <inheritdoc/>
    public class InvoiceOutApi :
        EntityApiAccessor<InvoiceOut, ApiParameterBuilder<InvoiceOutQuery>, ApiParameterBuilder<InvoiceOutQuery>>,
        IHasMetadataApi<MetadataApi<DocumentMetadata, DocumentMetadataQuery>>
    {
        #region Properties

        /// <inheritdoc/>
        public virtual MetadataApi<DocumentMetadata, DocumentMetadataQuery> Metadata { get; }

        #endregion Properties

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="InvoiceOutApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public InvoiceOutApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/invoiceout", httpClient, credentials)
        {
            Metadata = new MetadataApi<DocumentMetadata, DocumentMetadataQuery>(Path, httpClient, credentials);
        }

        #endregion Ctor
    }
}