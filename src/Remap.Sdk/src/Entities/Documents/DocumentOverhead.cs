﻿namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an document overhead.
    /// </summary>
    public class DocumentOverhead
    {
        #region Properties

        /// <summary>
        /// Gets or sets the overhead distribution type.
        /// </summary>
        /// <value>The overhead distribution type.</value>
        public OverheadDistributionType? Distribution { get; set; }

        /// <summary>
        /// Gets or sets the sum.
        /// </summary>
        /// <value>The sum.</value>
        public long? Sum { get; set; }

        #endregion Properties
    }
}