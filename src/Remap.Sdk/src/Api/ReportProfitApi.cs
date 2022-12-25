using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the <see cref="ReportProfit"/> endpoint.
    /// </summary>
    public class ReportProfitApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ReportProfitApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public ReportProfitApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/report/profit", httpClient, credentials)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Gets the profit report by product.
        /// </summary>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="EntitiesResponse{ReportProfitByProduct}"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<ReportProfitByProduct>>> GetByProductAsync(ApiParameterBuilder query = null)
        {
            var requestContext = new RequestContext($"{Path}/byproduct", HttpMethod.Get);

            if (query != null)
                requestContext.WithQuery(query.Build());

            return CallAsync<EntitiesResponse<ReportProfitByProduct>>(requestContext);
        }

        /// <summary>
        /// Gets the profit report by variant.
        /// </summary>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="EntitiesResponse{ReportProfitByVariant}"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<ReportProfitByVariant>>> GetByVariantAsync(ApiParameterBuilder query = null)
        {
            var requestContext = new RequestContext($"{Path}/byvariant", HttpMethod.Get);

            if (query != null)
                requestContext.WithQuery(query.Build());

            return CallAsync<EntitiesResponse<ReportProfitByVariant>>(requestContext);
        }

        /// <summary>
        /// Gets the profit report by employee.
        /// </summary>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="EntitiesResponse{ReportProfitByEmployee}"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<ReportProfitByEmployee>>> GetByEmployeeAsync(ApiParameterBuilder query = null)
        {
            var requestContext = new RequestContext($"{Path}/byemployee", HttpMethod.Get);

            if (query != null)
                requestContext.WithQuery(query.Build());

            return CallAsync<EntitiesResponse<ReportProfitByEmployee>>(requestContext);
        }

        /// <summary>
        /// Gets the profit report by counterparty.
        /// </summary>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="EntitiesResponse{ReportProfitByCounterparty}"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<ReportProfitByCounterparty>>> GetByCounterpartyAsync(ApiParameterBuilder query = null)
        {
            var requestContext = new RequestContext($"{Path}/bycounterparty", HttpMethod.Get);

            if (query != null)
                requestContext.WithQuery(query.Build());

            return CallAsync<EntitiesResponse<ReportProfitByCounterparty>>(requestContext);
        }

        /// <summary>
        /// Gets the profit report by sales channel.
        /// </summary>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="EntitiesResponse{ReportProfitByCounterparty}"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<ReportProfitBySalesChannel>>> GetBySalesChannelAsync(ApiParameterBuilder query = null)
        {
            var requestContext = new RequestContext($"{Path}/bysaleschannel", HttpMethod.Get);

            if (query != null)
                requestContext.WithQuery(query.Build());

            return CallAsync<EntitiesResponse<ReportProfitBySalesChannel>>(requestContext);
        }

        #endregion Methods
    }
}