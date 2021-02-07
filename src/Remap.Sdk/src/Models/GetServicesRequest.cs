using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents a request to get <see cref="Service"/>'s.
    /// </summary>
    public class GetServicesRequest
    {
        #region Properties

        /// <summary>
        /// Gets or sets the API parameter builder to prepare the request query.
        /// </summary>
        /// <returns>The API parameter builder.</returns>
        public AssortmentApiParameterBuilder<ServiceQuery> Query { get; set; } = new AssortmentApiParameterBuilder<ServiceQuery>();

        #endregion
    }
}
