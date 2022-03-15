using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the payment out endpoint.
    /// </summary>
    public class PaymentOutApi : ApiAccessor
    {
        #region Properties

        /// <summary>
        /// Gets the API to interact with the metadata endpoint. 
        /// </summary>
        public virtual MetadataApi<DocumentMetadata, DocumentMetadataQuery> Metadata { get; }

        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="PaymentOutApi" /> class
        /// with MoySklad credentials if specified and the HTTP client if specified (or use default).
        /// </summary>
        /// <param name="credentials">The MoySklad credentials.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public PaymentOutApi(MoySkladCredentials credentials = null, HttpClient httpClient = null)
            : base("/api/remap/1.2/entity/paymentout", credentials, httpClient)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the payments out.
        /// </summary>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="GetPaymentsOutResponse"/>.</returns>
        public virtual Task<ApiResponse<GetPaymentsOutResponse>> GetAllAsync() => GetAsync<GetPaymentsOutResponse>();

        /// <summary>
        /// Gets the payment out by id.
        /// </summary>
        /// <param name="request">The payment out request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="PaymentOut"/>.</returns>
        public virtual Task<ApiResponse<PaymentOut>> GetAsync(GetPaymentOutRequest request) => GetByIdAsync<PaymentOut>(request.Id);

        /// <summary>
        /// Creates the payment out.
        /// </summary>
        /// <param name="paymentOut">The payment out.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="PaymentOut"/>.</returns>
        public virtual Task<ApiResponse<PaymentOut>> CreateAsync(PaymentOut paymentOut) => CreateAsync(paymentOut);

        /// <summary>
        /// Updates the payment out.
        /// </summary>
        /// <param name="paymentOut">The payment out.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="PaymentOut"/>.</returns>
        public virtual Task<ApiResponse<PaymentOut>> UpdateAsync(PaymentOut paymentOut) => UpdateAsync(paymentOut);

        /// <summary>
        /// Deletes the payment out.
        /// </summary>
        /// <param name="paymentOut">The payment out.</param>
        /// <returns>The <see cref="Task"/> containing the API response.</returns>
        public virtual Task<ApiResponse> DeleteAsync(PaymentOut paymentOut) => DeleteAsync(paymentOut);

        #endregion
    }
}
