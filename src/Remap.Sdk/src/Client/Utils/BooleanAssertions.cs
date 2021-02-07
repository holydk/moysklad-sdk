using System.Collections.Generic;
using System.Linq.Expressions;

namespace Confiti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents the assertions to build the boolean API parameter.
    /// </summary>
    public class BooleanAssertions : AbstractAssertions
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="BooleanAssertions" /> class
        /// with the parameter expression and the filters.
        /// </summary>
        /// <param name="parameter">The parameter expression.</param>
        /// <param name="filters">The filters.</param>
        protected internal BooleanAssertions(LambdaExpression parameter, List<FilterItem> filters)
            : base(parameter, filters)
        {
        }
            
        #endregion

        #region Methods

        /// <summary>
        /// Asserts that a parameter should has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The or constraint.</returns>
        public OrConstraint<BooleanAssertions> Be(bool value)
        {
            AddFilter(value.ToString().ToLower(), "=", new[] { "=" });
            return new OrConstraint<BooleanAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should not has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<BooleanAssertions> NotBe(bool value)
        {
            AddFilter(value.ToString().ToLower(), "!=", new[] { "!=" });
            return new AndConstraint<BooleanAssertions>(this);
        }
            
        #endregion
    }
}