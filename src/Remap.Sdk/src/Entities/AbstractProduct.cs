using System;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an abstract product.
    /// </summary>
    public abstract class AbstractProduct : MetaEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether to the entity is archived.
        /// </summary>
        /// <value>The value indicating whether to the entity is archived.</value>
        public bool? Archived { get; set; }

        /// <summary>
        /// Gets or sets the buy price.
        /// </summary>
        /// <value>The buy price.</value>
        public Price BuyPrice { get; set; }


        /// <summary>
        /// Gets or sets the minimum price.
        /// </summary>
        /// <value>The minimum price.</value>
        public Price MinPrice { get; set; }

        /// <summary>
        /// Gets or sets the barcodes.
        /// </summary>
        /// <value>The barcodes.</value>
        public Barcode[] Barcodes { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the sale prices.
        /// </summary>
        /// <value>The sale prices.</value>
        public Price[] SalePrices { get; set; }

        /// <summary>
        /// Gets or sets the external code.
        /// </summary>
        /// <value>The external code.</value>
        public string ExternalCode { get; set; }

        /// <summary>
        /// Gets or sets the date when the entity has been updated.
        /// </summary>
        /// <value>The date when the entity has been updated.</value>
        public DateTime? Updated { get; set; }

        #endregion Properties
    }
}
