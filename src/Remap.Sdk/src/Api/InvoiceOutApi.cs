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
        /// with the base API path.
        /// </summary>
        /// <param name="basePath">The API base path.</param>
        public InvoiceOutApi(string basePath)
            : base(basePath, "/api/remap/1.2/entity/invoiceout")
        {
            Metadata = new MetadataApi<DocumentMetadata, DocumentMetadataQuery>(basePath, Path);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="InvoiceOutApi" /> class
        /// with the API configuration.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        public InvoiceOutApi(Configuration configuration = null)
            : base("/api/remap/1.2/entity/invoiceout", configuration)
        {
            Metadata = new MetadataApi<DocumentMetadata, DocumentMetadataQuery>(Path, configuration);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates the invoice out.
        /// </summary>
        /// <param name="invoiceOut">The invoice out.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="InvoiceOut"/>.</returns>
        public virtual Task<ApiResponse<InvoiceOut>> CreateAsync(InvoiceOut invoiceOut)
        {
            if (invoiceOut == null)
                throw new ArgumentNullException(nameof(invoiceOut));

            var requestContext = PrepareRequestContext(method: Method.POST).WithBody(Serialize(invoiceOut));
            return CallAsync<InvoiceOut>(requestContext);
        }

        #endregion
    }
}
