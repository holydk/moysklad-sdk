using System;

namespace Confiti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents the attribute to set the filter rules.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class FilterAttribute : Attribute
    {
        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether to the member is allow to continue constraint.
        /// </summary>
        /// <value>The value indicating whether to the member is allow to continue constraint.</value>
        public bool AllowContinueConstraint { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the member is allow filter by root nesting member.
        /// </summary>
        /// <value>The value indicating whether to the member is allow filter by root nesting member.</value>
        public bool AllowFilterByRootNestingMember { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the member is allow have nesting.
        /// </summary>
        /// <value>The value indicating whether to the member is allow have nesting.</value>
        public bool AllowNesting { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to the member is allow have null value.
        /// </summary>
        /// <value>The value indicating whether to the member is allow have null value.</value>
        public bool AllowNull { get; set; }

        /// <summary>
        /// Gets or sets the overridden operators.
        /// </summary>
        /// <value>The overridden operators.</value>
        public string[] OverriddenOperators { get; set; }

        #endregion Properties

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="FilterAttribute" /> class.
        /// </summary>
        /// <param name="allowNull">The value indicating whether to the member is allow have null value.</param>
        /// <param name="allowNesting">The value indicating whether to the member is allow have nesting.</param>
        /// <param name="allowFilterByRootNestingMember">The value indicating whether to the member is allow filter by root nesting member.</param>
        /// <param name="allowContinueConstraint">The value indicating whether to the member is allow to continue constraint.</param>
        /// <param name="overriddenOperators">The overridden operators.</param>
        public FilterAttribute(
            bool allowNull = true,
            bool allowNesting = false,
            bool allowFilterByRootNestingMember = true,
            bool allowContinueConstraint = true,
            string[] overriddenOperators = null)
        {
            AllowNull = allowNull;
            AllowNesting = allowNesting;
            AllowFilterByRootNestingMember = allowFilterByRootNestingMember;
            AllowContinueConstraint = allowContinueConstraint;
            OverriddenOperators = overriddenOperators;
        }

        #endregion Ctor
    }
}