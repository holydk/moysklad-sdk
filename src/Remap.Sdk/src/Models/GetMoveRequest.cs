using System;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents a request to get <see cref="Move"/>.
    /// </summary>
    public class GetMoveRequest
    {
        #region Properties

        /// <summary>
        /// Gets or sets the move id.
        /// </summary>
        /// <value>The move id.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the API parameter builder to prepare the request query.
        /// </summary>
        /// <returns>The API parameter builder.</returns>
        public ApiParameterBuilder<MoveQuery> Query { get; set; } = new ApiParameterBuilder<MoveQuery>();

        #endregion
    }
}