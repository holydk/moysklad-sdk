using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents a request to get <see cref="Counterparty"/>'s.
    /// </summary>
    public class GetCounterpartiesRequest
    {
        #region Properties

        /// <summary>
        /// Gets or sets the API parameter builder to prepare the request query.
        /// </summary>
        /// <returns>The API parameter builder.</returns>
        public ApiParameterBuilder<CounterpartiesQuery> Query { get; set; } = new ApiParameterBuilder<CounterpartiesQuery>();
            
        #endregion
    }
}