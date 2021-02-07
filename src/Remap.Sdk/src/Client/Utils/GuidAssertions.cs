using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Confiti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents the assertions to build the guid API parameter.
    /// </summary>
    public class GuidAssertions : AbstractAssertions
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="GuidAssertions" /> class
        /// with the parameter expression and the filters.
        /// </summary>
        /// <param name="parameter">The parameter expression.</param>
        /// <param name="filters">The filters.</param>
        protected internal GuidAssertions(LambdaExpression parameter, List<FilterItem> filters)
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
        public OrConstraint<GuidAssertions> Be(Guid value)
        {
            AddFilter(value.ToString(), "=", new[] { "=" });
            return new OrConstraint<GuidAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should not has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<GuidAssertions> NotBe(Guid value)
        {
            AddFilter(value.ToString(), "!=", new[] { "!=" });
            return new AndConstraint<GuidAssertions>(this);
        }
            
        #endregion
    }
}