﻿using System.Net.Http;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Queries;

namespace Confiti.MoySklad.Remap.Api
{
    /// <inheritdoc/>
    public class BundleApi : EntityApiAccessor<Bundle, ApiParameterBuilder, ApiParameterBuilder>, IHasImageApi
    {
        #region Properties

        /// <inheritdoc/>
        public virtual ImageApi Images { get; }

        #endregion Properties

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="BundleApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public BundleApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/bundle", httpClient, credentials)
        {
            Images = new ImageApi(Path, httpClient, credentials);
        }

        #endregion Ctor
    }
}