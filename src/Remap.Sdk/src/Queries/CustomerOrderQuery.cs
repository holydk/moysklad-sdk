using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents a <see cref="CustomerOrder"/> query.
    /// </summary>
    public class CustomerOrderQuery
    {
        #region Properties

        /// <summary>
        /// Gets or sets the contract.
        /// Note: 'expand' is allowed.
        /// </summary>
        /// <value>The contract.</value>
        [AllowExpand]
        [Parameter("contract")]
        public Contract Contract { get; set; }

        /// <summary>
        /// Gets or sets the positions.
        /// Note: 'expand' is allowed.
        /// </summary>
        /// <value>The positions.</value>
        [AllowExpand]
        [Parameter("positions")]
        public PagedEntities<CustomerOrderPosition> Positions { get; set; }

        #endregion Properties
    }
}