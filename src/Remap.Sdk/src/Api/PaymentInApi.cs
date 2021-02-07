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
        /// with the base API path.
        /// </summary>
        /// <param name="basePath">The API base path.</param>
        public PaymentInApi(string basePath)
            : base(basePath, "/api/remap/1.2/entity/paymentin")
        {
            Metadata = new MetadataApi<DocumentMetadata, DocumentMetadataQuery>(basePath, Path);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="PaymentInApi" /> class
        /// with the API configuration.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        public PaymentInApi(Configuration configuration = null)
            : base("/api/remap/1.2/entity/paymentin", configuration)
        {
            Metadata = new MetadataApi<DocumentMetadata, DocumentMetadataQuery>(Path, configuration);
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

            var requestContext = PrepareRequestContext(method: Method.POST).WithBody(Serialize(paymentIn));
            return CallAsync<PaymentIn>(requestContext);
        }

        #endregion
    }
}
