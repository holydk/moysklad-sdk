using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the invoice out endpoint.
    /// </summary>
    public class InvoiceOutApi : ApiAccessor
    {
        #region Properties

        /// <summary>
        /// Gets the API to interact with the metadata endpoint. 
        /// </summary>
        public virtual MetadataApi<DocumentMetadata, DocumentMetadataQuery> Metadata { get; }

        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="InvoiceOutApi" /> class
        /// with MoySklad credentials if specified and the HTTP client if specified (or use default).
        /// </summary>
        /// <param name="credentials">The MoySklad credentials.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public InvoiceOutApi(MoySkladCredentials credentials = null, HttpClient httpClient = null)
            : base("/api/remap/1.2/entity/invoiceout", credentials, httpClient)
        {
            Metadata = new MetadataApi<DocumentMetadata, DocumentMetadataQuery>(Path, credentials, httpClient);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the invoice out by id.
        /// </summary>
        /// <param name="request">The invoice out request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="InvoiceOut"/>.</returns>
        public virtual Task<ApiResponse<InvoiceOut>> GetAsync(GetInvoiceOutRequest request) => GetByIdAsync<InvoiceOut>(request.Id, request.Query);

        /// <summary>
        /// Creates the invoice out.
        /// </summary>
        /// <param name="invoiceOut">The invoice out.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="InvoiceOut"/>.</returns>
        public virtual Task<ApiResponse<InvoiceOut>> CreateAsync(InvoiceOut invoiceOut) => CreateAsync(invoiceOut);

        /// <summary>
        /// Updates the invoice out.
        /// </summary>
        /// <param name="invoiceOut">The invoice out.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="InvoiceOut"/>.</returns>
        public virtual Task<ApiResponse<InvoiceOut>> UpdateAsync(InvoiceOut invoiceOut) => UpdateAsync(invoiceOut);

        #endregion
    }
}
