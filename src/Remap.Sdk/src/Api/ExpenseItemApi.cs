using System.Net.Http;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Queries;

namespace Confiti.MoySklad.Remap.Api
{
    /// <inheritdoc/>
    public class ExpenseItemApi : EntityApiAccessor<ExpenseItem, ApiParameterBuilder, ApiParameterBuilder>
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
    }
}