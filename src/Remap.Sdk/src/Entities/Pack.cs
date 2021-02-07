using System;
using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an pack (e.g. pack of products).
    /// </summary>
    public class Pack
    {
        #region Properties

        /// <summary>
        /// Gets or sets the pack id.
        /// </summary>
        /// <value>The pack id.</value>
        [JsonProperty("id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the unit of measure.
        /// </summary>
        /// <value>The unit of measure.</value>
        [JsonProperty("uom")]
        public Uom Uom { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        [JsonProperty("quantity")]
        public double? Quantity { get; set; }

        /// <summary>
        /// Gets or sets the barcodes.
        /// </summary>
        /// <value>The barcodes.</value>
        [JsonProperty("barcodes")]
        public Barcode[] Barcodes { get; set; }
            
        #endregion
    }
}