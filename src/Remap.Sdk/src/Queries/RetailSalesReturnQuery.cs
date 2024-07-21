using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents a <see cref="RetailSalesReturn"/> query.
    /// </summary>
    public class RetailSalesReturnQuery
    {
        #region Properties

        /// <summary>
        /// Gets or sets the positions.
        /// Note: 'expand' is allowed.
        /// </summary>
        /// <value>The positions.</value>
        [AllowExpand]
        [Parameter("positions")]
        public PagedEntities<RetailSalesPosition> Positions { get; set; }

        #endregion Properties
    }
}