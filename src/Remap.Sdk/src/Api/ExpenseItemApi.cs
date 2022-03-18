using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Models;
using System;
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
        /// with MoySklad credentials factory if specified and the HTTP client factory if specified (or use default).
        /// </summary>
        /// <param name="credentialsFactory">The factory to create the MoySklad credentials.</param>
        /// <param name="httpClientFactory">The factory to create the HTTP client.</param>
        public ExpenseItemApi(Func<MoySkladCredentials> credentialsFactory = null, Func<HttpClient> httpClientFactory = null)
            : base("/api/remap/1.2/entity/expenseitem", credentialsFactory, httpClientFactory)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the expense items.
        /// </summary>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="GetExpenseItemsResponse"/>.</returns>
        public virtual Task<ApiResponse<GetExpenseItemsResponse>> GetAllAsync() => GetAsync<GetExpenseItemsResponse>();

        #endregion
    }
}
