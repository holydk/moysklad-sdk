using System;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents a request to get <see cref="Image"/>'s.
    /// </summary>
    public class GetImagesRequest
    {
        #region Properties

        /// <summary>
        /// Gets or sets the entity id.
        /// </summary>
        /// <value>The entity id.</value>
        public Guid EntityId { get; set; }

        /// <summary>
        /// Gets or sets the API parameter builder to prepare the request query.
        /// </summary>
        /// <returns>The API parameter builder.</returns>
        public ApiParameterBuilder<Image> Query { get; set; } = new ApiParameterBuilder<Image>();
            
        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="GetImagesRequest" /> class
        /// with entity id.
        /// </summary>
        /// <param name="entityId">The entity id.</param>
        public GetImagesRequest(Guid entityId)
        {
            EntityId = entityId;
        }
            
        #endregion
    }
}