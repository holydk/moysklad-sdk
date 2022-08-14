using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the payment in endpoint.
    /// </summary>
    public class PaymentInApi : ApiAccessor
    {
        #region Properties

        /// <summary>
        /// Gets the API to interact with the metadata endpoint. 
        /// </summary>
        public virtual MetadataApi<DocumentMetadata, DocumentMetadataQuery> Metadata { get; }

        #endregion

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

        #endregion

        #region Methods

        /// <summary>
        /// Gets the payment in by id.
        /// </summary>
        /// <param name="id">The id to get the entity.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="PaymentIn"/>.</returns>
        public virtual Task<ApiResponse<PaymentIn>> GetAsync(Guid id) => GetByIdAsync<PaymentIn>(id);

        /// <summary>
        /// Creates the payment in.
        /// </summary>
        /// <param name="paymentIn">The payment in.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="PaymentIn"/>.</returns>
        public virtual Task<ApiResponse<PaymentIn>> CreateAsync(PaymentIn paymentIn) => CreateAsync<PaymentIn>(paymentIn);

        /// <summary>
        /// Updates the payment in.
        /// </summary>
        /// <param name="paymentIn">The payment in.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="PaymentIn"/>.</returns>
        public virtual Task<ApiResponse<PaymentIn>> UpdateAsync(PaymentIn paymentIn) => UpdateAsync<PaymentIn>(paymentIn);

        #endregion
    }
}
