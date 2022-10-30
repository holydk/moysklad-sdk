using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;

namespace Confiti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents a <see cref="ProductMetadata"/> query.
    /// </summary>
    public class ProductMetadataQuery
    {
        #region Properties

        /// <summary>
        /// Gets or sets the attributes.
        /// Note: 'expand' is allowed.
        /// </summary>
        /// <value>The attributes.</value>
        [AllowExpand]
        [Parameter("attributes")]
        public PagedMetaEntities<AttributeDefinition> Attributes { get; set; }

        #endregion Properties
    }
}