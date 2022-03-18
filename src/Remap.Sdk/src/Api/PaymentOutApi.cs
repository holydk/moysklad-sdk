using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
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
        /// with MoySklad credentials factory if specified and the HTTP client factory if specified (or use default).
        /// </summary>
        /// <param name="credentialsFactory">The factory to create the MoySklad credentials.</param>
        /// <param name="httpClientFactory">The factory to create the HTTP client.</param>
        public PaymentOutApi(Func<MoySkladCredentials> credentialsFactory = null, Func<HttpClient> httpClientFactory = null)
            : base("/api/remap/1.2/entity/paymentout", credentialsFactory, httpClientFactory)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the payments out.
        /// </summary>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="EntitiesResponse{PaymentOut}"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<PaymentOut>>> GetAllAsync(ApiParameterBuilder query = null) => GetAsync<EntitiesResponse<PaymentOut>>();

        /// <summary>
        /// Gets the payment out by id.
        /// </summary>
        /// <param name="id">The id to get the entity.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="PaymentOut"/>.</returns>
        public virtual Task<ApiResponse<PaymentOut>> GetAsync(Guid id) => GetByIdAsync<PaymentOut>(id);

        /// <summary>
        /// Creates the payment out.
        /// </summary>
        /// <param name="paymentOut">The payment out.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="PaymentOut"/>.</returns>
        public virtual Task<ApiResponse<PaymentOut>> CreateAsync(PaymentOut paymentOut) => CreateAsync<PaymentOut>(paymentOut);

        /// <summary>
        /// Updates the payment out.
        /// </summary>
        /// <param name="paymentOut">The payment out.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="PaymentOut"/>.</returns>
        public virtual Task<ApiResponse<PaymentOut>> UpdateAsync(PaymentOut paymentOut) => UpdateAsync<PaymentOut>(paymentOut);

        #endregion
    }
}
