using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the expense item endpoint.
    /// </summary>
    public class ExpenseItemApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ExpenseItemApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public ExpenseItemApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/expenseitem", httpClient, credentials)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Gets the expense items.
        /// </summary>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="EntitiesResponse{ExpenseItem}"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<ExpenseItem>>> GetAllAsync(ApiParameterBuilder query = null) => GetAsync<EntitiesResponse<ExpenseItem>>(query);

        #endregion Methods
    }
}