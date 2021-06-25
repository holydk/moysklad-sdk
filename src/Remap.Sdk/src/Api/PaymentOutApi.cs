using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the payment out endpoint.
    /// </summary>
    public class PaymentOutApi : ApiAccessorBase
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
        /// with the API configuration is specified (or use <see cref="Configuration.Default" />) and base API path.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        /// <param name="basePath">The API base path.</param>
        public PaymentOutApi(Configuration configuration = null, string basePath = null)
            : base("/api/remap/1.2/entity/paymentout", basePath, configuration)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the payments out.
        /// </summary>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="GetPaymentsOutResponse"/>.</returns>
        public virtual Task<ApiResponse<GetPaymentsOutResponse>> GetAllAsync()
        {
            var requestContext = PrepareRequestContext();
            return CallAsync<GetPaymentsOutResponse>(requestContext);
        }

        /// <summary>
        /// Gets the payment out by id.
        /// </summary>
        /// <param name="request">The payment out request.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="PaymentOut"/>.</returns>
        public virtual Task<ApiResponse<PaymentOut>> GetAsync(GetPaymentOutRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var requestContext = PrepareRequestContext(path: $"{Path}/{request.Id}");
            return CallAsync<PaymentOut>(requestContext);
        }

        /// <summary>
        /// Creates the payment out.
        /// </summary>
        /// <param name="paymentOut">The payment out.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="PaymentOut"/>.</returns>
        public virtual Task<ApiResponse<PaymentOut>> CreateAsync(PaymentOut paymentOut)
        {
            if (paymentOut == null)
                throw new ArgumentNullException(nameof(paymentOut));

            var requestContext = PrepareRequestContext(method: Method.POST)
                .WithBody(Serialize(paymentOut));
            return CallAsync<PaymentOut>(requestContext);
        }

        /// <summary>
        /// Updates the payment out.
        /// </summary>
        /// <param name="paymentOut">The payment out.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="PaymentOut"/>.</returns>
        public virtual Task<ApiResponse<PaymentOut>> UpdateAsync(PaymentOut paymentOut)
        {
            if (paymentOut == null)
                throw new ArgumentNullException(nameof(paymentOut));

            var requestContext = PrepareRequestContext(method: Method.PUT, path: $"{Path}/{paymentOut.Id}")
                .WithBody(Serialize(paymentOut));
            return CallAsync<PaymentOut>(requestContext);
        }

        /// <summary>
        /// Deletes the payment out.
        /// </summary>
        /// <param name="paymentOut">The payment out.</param>
        /// <returns>The <see cref="Task"/> containing the API response.</returns>
        public virtual Task<ApiResponse> DeleteAsync(PaymentOut paymentOut)
        {
            if (paymentOut == null)
                throw new ArgumentNullException(nameof(paymentOut));

            var requestContext = PrepareRequestContext(method: Method.DELETE, path: $"{Path}/{paymentOut.Id}");
            return CallAsync(requestContext);
        }

        #endregion
    }
}
