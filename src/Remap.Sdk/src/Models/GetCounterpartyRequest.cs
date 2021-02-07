using System;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents a request to get <see cref="Counterparty"/>.
    /// </summary>
    public class GetCounterpartyRequest
    {
        #region Properties

        /// <summary>
        /// Gets or sets the counterparty id.
        /// </summary>
        /// <value>The counterparty id.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the API parameter builder to prepare the request query.
        /// </summary>
        /// <returns>The API parameter builder.</returns>
        public ApiParameterBuilder<CounterpartyQuery> Query { get; set; } = new ApiParameterBuilder<CounterpartyQuery>();
            
        #endregion
    }
}