using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents a request to get <see cref="Variant"/>'s.
    /// </summary>
    public class GetVariantsRequest
    {
        #region Properties

        /// <summary>
        /// Gets or sets the API parameter builder to prepare the request query.
        /// </summary>
        /// <returns>The API parameter builder.</returns>
        public ApiParameterBuilder<VariantsQuery> Query { get; set; } = new ApiParameterBuilder<VariantsQuery>();

        #endregion
    }
}
