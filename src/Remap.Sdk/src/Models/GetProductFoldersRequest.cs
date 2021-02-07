using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents a request to get <see cref="ProductFolder"/>'s.
    /// </summary>
    public class GetProductFoldersRequest
    {
        #region Properties

        /// <summary>
        /// Gets or sets the API parameter builder to prepare the request query.
        /// </summary>
        /// <returns>The API parameter builder.</returns>
        public ApiParameterBuilder<ProductFolderQuery> Query { get; set; } = new ApiParameterBuilder<ProductFolderQuery>();
            
        #endregion
    }
}