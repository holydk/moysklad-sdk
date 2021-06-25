using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Models;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the expense item endpoint.
    /// </summary>
    public class ExpenseItemApi : ApiAccessorBase
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ExpenseItemApi" /> class
        /// with the API configuration is specified (or use <see cref="Configuration.Default" />) and base API path.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        /// <param name="basePath">The API base path.</param>
        public ExpenseItemApi(Configuration configuration = null, string basePath = null)
            : base("/api/remap/1.2/entity/expenseitem", basePath, configuration)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the expense items.
        /// </summary>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="GetExpenseItemsResponse"/>.</returns>
        public virtual Task<ApiResponse<GetExpenseItemsResponse>> GetAllAsync()
        {
            var requestContext = PrepareRequestContext();
            return CallAsync<GetExpenseItemsResponse>(requestContext);
        }

        #endregion
    }
}
