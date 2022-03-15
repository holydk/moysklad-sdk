using Confiti.MoySklad.Remap.Client;
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
        /// with MoySklad credentials if specified and the HTTP client if specified (or use default).
        /// </summary>
        /// <param name="credentials">The MoySklad credentials.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public ExpenseItemApi(MoySkladCredentials credentials = null, HttpClient httpClient = null)
            : base("/api/remap/1.2/entity/expenseitem", credentials, httpClient)
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
