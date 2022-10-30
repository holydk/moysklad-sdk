using System;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an pack (e.g. pack of products).
    /// </summary>
    public class Pack
    {
        #region Properties

        /// <summary>
        /// Gets or sets the barcodes.
        /// </summary>
        /// <value>The barcodes.</value>
        public Barcode[] Barcodes { get; set; }

        /// <summary>
        /// Gets or sets the pack id.
        /// </summary>
        /// <value>The pack id.</value>
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public double? Quantity { get; set; }

        /// <summary>
        /// Gets or sets the unit of measure.
        /// </summary>
        /// <value>The unit of measure.</value>
        public Uom Uom { get; set; }

        #endregion Properties
    }
}