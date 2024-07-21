namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents a quantity mode parameter for the assortment request.
    /// </summary>
    public enum QuantityMode
    {
        /// <summary>
        /// Uses to get the any availability.
        /// </summary>
        [Parameter("all")]
        All,

        /// <summary>
        /// Uses to get the positive availability.
        /// </summary>
        [Parameter("positiveOnly")]
        PositiveOnly,

        /// <summary>
        /// Uses to get the negative availability.
        /// </summary>
        [Parameter("negativeOnly")]
        NegativeOnly,

        /// <summary>
        /// Uses to get the zero availability.
        /// </summary>
        [Parameter("empty")]
        Empty,

        /// <summary>
        /// Uses to get the non-zero availability.
        /// </summary>
        [Parameter("nonEmpty")]
        NonEmpty,

        /// <summary>
        /// Uses to get the under minimum availability.
        /// </summary>
        [Parameter("underMinimum")]
        UnderMinimum
    }
}