using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the invoice out endpoint.
    /// </summary>
    public class InvoiceOutApi : ApiAccessorBase
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
        /// with the API configuration is specified (or use <see cref="Configuration.Default" />) and base API path.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        /// <param name="basePath">The API base path.</param>
        public InvoiceOutApi(Configuration configuration = null, string basePath = null)
            : base("/api/remap/1.2/entity/invoiceout", basePath, configuration)
        {
            Metadata = new MetadataApi<DocumentMetadata, DocumentMetadataQuery>(Path, basePath, configuration);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the invoice out by id.
        /// </summary>
        /// <param name="request">The invoice out request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="InvoiceOut"/>.</returns>
        public virtual Task<ApiResponse<InvoiceOut>> GetAsync(GetInvoiceOutRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var requestContext = PrepareRequestContext(path: $"{Path}/{request.Id}")
                .WithQuery(request.Query.Build());
            return CallAsync<InvoiceOut>(requestContext);
        }

        /// <summary>
        /// Creates the invoice out.
        /// </summary>
        /// <param name="invoiceOut">The invoice out.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="InvoiceOut"/>.</returns>
        public virtual Task<ApiResponse<InvoiceOut>> CreateAsync(InvoiceOut invoiceOut)
        {
            if (invoiceOut == null)
                throw new ArgumentNullException(nameof(invoiceOut));

            var requestContext = PrepareRequestContext(method: Method.POST)
                .WithBody(Serialize(invoiceOut));
            return CallAsync<InvoiceOut>(requestContext);
        }

        /// <summary>
        /// Updates the invoice out.
        /// </summary>
        /// <param name="invoiceOut">The invoice out.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="InvoiceOut"/>.</returns>
        public virtual Task<ApiResponse<InvoiceOut>> UpdateAsync(InvoiceOut invoiceOut)
        {
            if (invoiceOut == null)
                throw new ArgumentNullException(nameof(invoiceOut));

            var requestContext = PrepareRequestContext(method: Method.PUT, path: $"{Path}/{invoiceOut.Id}")
                .WithBody(Serialize(invoiceOut));
            return CallAsync<InvoiceOut>(requestContext);
        }

        #endregion
    }
}
