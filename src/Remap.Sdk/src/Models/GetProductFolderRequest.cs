using System;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents a request to get <see cref="ProductFolder"/>.
    /// </summary>
    public class GetProductFolderRequest
    {
        #region Properties

        /// <summary>
        /// Gets or sets the product folder id.
        /// </summary>
        /// <value>The product folder id.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the API parameter builder to prepare the request query.
        /// </summary>
        /// <returns>The API parameter builder.</returns>
        public ApiParameterBuilder<ProductFolderQuery> Query { get; set; } = new ApiParameterBuilder<ProductFolderQuery>();
            
        #endregion
    }
}