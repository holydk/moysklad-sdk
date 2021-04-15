using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the payment in endpoint.
    /// </summary>
    public class PaymentInApi : ApiAccessorBase
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
        /// with the API configuration is specified (or use <see cref="Configuration.Default" />) and base API path.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        /// <param name="basePath">The API base path.</param>
        public PaymentInApi(Configuration configuration = null, string basePath = null)
            : base("/api/remap/1.2/entity/paymentin", basePath, configuration)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates the payment in.
        /// </summary>
        /// <param name="paymentIn">The payment in.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="PaymentIn"/>.</returns>
        public virtual Task<ApiResponse<PaymentIn>> CreateAsync(PaymentIn paymentIn)
        {
            if (paymentIn == null)
                throw new ArgumentNullException(nameof(paymentIn));

            var requestContext = PrepareRequestContext(method: Method.POST)
                .WithBody(Serialize(paymentIn));
            return CallAsync<PaymentIn>(requestContext);
        }

        /// <summary>
        /// Updates the payment in.
        /// </summary>
        /// <param name="paymentIn">The payment in.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="PaymentIn"/>.</returns>
        public virtual Task<ApiResponse<PaymentIn>> UpdateAsync(PaymentIn paymentIn)
        {
            if (paymentIn == null)
                throw new ArgumentNullException(nameof(paymentIn));

            var requestContext = PrepareRequestContext(method: Method.PUT, path: $"{Path}/{paymentIn.Id}")
                .WithBody(Serialize(paymentIn));
            return CallAsync<PaymentIn>(requestContext);
        }

        #endregion
    }
}
