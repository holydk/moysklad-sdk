using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents a <see cref="SalesReturn"/> query.
    /// </summary>
    public class SalesReturnQuery
    {
        #region Properties

        /// <summary>
        /// Gets or sets the positions.
        /// Note: 'expand' is allowed.
        /// </summary>
        /// <value>The positions.</value>
        [AllowExpand]
        [Parameter("positions")]
        public PagedMetaEntities<SalesReturnPosition> Positions { get; set; }

        /// <summary>
        /// Gets or sets the demand.
        /// Note: 'expand' is allowed.
        /// </summary>
        /// <value>The demand.</value>
        [AllowExpand]
        [Parameter("demand")]
        public Demand Demand { get; set; }

        #endregion
    }
}
