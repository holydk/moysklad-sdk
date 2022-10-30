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

        #endregion Properties

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="PaymentOutApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public PaymentOutApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/paymentout", httpClient, credentials)
        {
            Metadata = new MetadataApi<DocumentMetadata, DocumentMetadataQuery>(Path, httpClient, credentials);
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Creates the payment out.
        /// </summary>
        /// <param name="paymentOut">The payment out.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="PaymentOut"/>.</returns>
        public virtual Task<ApiResponse<PaymentOut>> CreateAsync(PaymentOut paymentOut) => CreateAsync<PaymentOut>(paymentOut);

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
        /// Updates the payment out.
        /// </summary>
        /// <param name="paymentOut">The payment out.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="PaymentOut"/>.</returns>
        public virtual Task<ApiResponse<PaymentOut>> UpdateAsync(PaymentOut paymentOut) => UpdateAsync<PaymentOut>(paymentOut);

        #endregion Methods
    }
}