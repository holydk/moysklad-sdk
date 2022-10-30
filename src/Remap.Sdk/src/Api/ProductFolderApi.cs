using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System.Net.Http;

namespace Confiti.MoySklad.Remap.Api
{
    /// <inheritdoc/>
    public class ProductFolderApi : EntityApiAccessor<ProductFolder, ApiParameterBuilder<ProductFolderQuery>, ApiParameterBuilder<ProductFolderQuery>>
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ProductFolderApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public ProductFolderApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/productfolder", httpClient, credentials)
        {
        }

        #endregion Ctor
    }
}