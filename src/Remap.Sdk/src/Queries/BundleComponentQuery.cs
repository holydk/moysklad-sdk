using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents a bundle component query.
    /// </summary>
    public class BundleComponentQuery
    {
        #region Properties

        /// <summary>
        /// Gets or sets the abstract product.
        /// Note: 'expand' is allowed.
        /// </summary>
        /// <value>The abstract product.</value>
        [AllowExpand]
        [Parameter("assortment")]
        public AbstractProduct Assortment { get; set; }

        #endregion Properties
    }
}