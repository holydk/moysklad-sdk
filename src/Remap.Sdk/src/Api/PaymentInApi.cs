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
        /// with MoySklad credentials if specified and the HTTP client if specified (or use default).
        /// </summary>
        /// <param name="credentials">The MoySklad credentials.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public PaymentInApi(MoySkladCredentials credentials = null, HttpClient httpClient = null)
            : base("/api/remap/1.2/entity/paymentin", credentials, httpClient)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the payment in by id.
        /// </summary>
        /// <param name="request">The payment in request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="PaymentIn"/>.</returns>
        public virtual Task<ApiResponse<PaymentIn>> GetAsync(GetPaymentInRequest request) => GetByIdAsync<PaymentIn>(request.Id);

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
