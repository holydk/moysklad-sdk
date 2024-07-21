namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents a filter item.
    /// </summary>
    public class FilterItem
    {
        #region Properties

        /// <summary>
        /// Get the parameter name.
        /// </summary>
        /// <value>The parameter name.</value>
        public string Name { get; }

        /// <summary>
        /// Get the operator name.
        /// </summary>
        /// <value>The operator name.</value>
        public string Operator { get; }

        /// <summary>
        /// Get the parameter value.
        /// </summary>
        /// <value>The parameter value.</value>
        public string Value { get; }

        #endregion Properties

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="FilterItem" /> class
        /// with the parameter name, operator name and parameter value.
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="operator">The operator name.</param>
        /// <param name="value">The parameter value.</param>
        public FilterItem(string name, string @operator, string value)
        {
            Name = name;
            Operator = @operator;
            Value = value;
        }

        #endregion Ctor
    }
}