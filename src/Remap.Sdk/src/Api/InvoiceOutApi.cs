using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
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

        #region Methods

        /// <summary>
        /// Creates the invoice out.
        /// </summary>
        /// <param name="invoiceOut">The invoice out.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="InvoiceOut"/>.</returns>
        public virtual Task<ApiResponse<InvoiceOut>> CreateAsync(InvoiceOut invoiceOut) => CreateAsync<InvoiceOut>(invoiceOut);

        /// <summary>
        /// Gets the invoice out by id.
        /// </summary>
        /// <param name="id">The id to get the entity.</param>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="InvoiceOut"/>.</returns>
        public virtual Task<ApiResponse<InvoiceOut>> GetAsync(Guid id, ApiParameterBuilder<InvoiceOutQuery> query = null) => GetByIdAsync<InvoiceOut>(id, query);

        /// <summary>
        /// Updates the invoice out.
        /// </summary>
        /// <param name="invoiceOut">The invoice out.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="InvoiceOut"/>.</returns>
        public virtual Task<ApiResponse<InvoiceOut>> UpdateAsync(InvoiceOut invoiceOut) => UpdateAsync<InvoiceOut>(invoiceOut);

        #endregion Methods
    }
}