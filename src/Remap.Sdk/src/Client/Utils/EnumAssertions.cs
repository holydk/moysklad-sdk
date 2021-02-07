using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Confiti.MoySklad.Remap.Extensions;

namespace Confiti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents the assertions to build the enum API parameter.
    /// </summary>
    public class EnumAssertions<T> : AbstractAssertions where T : Enum
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="EnumAssertions{T}" /> class
        /// with the parameter expression and the filters.
        /// </summary>
        /// <param name="parameter">The parameter expression.</param>
        /// <param name="filters">The filters.</param>
        internal EnumAssertions(LambdaExpression parameter, List<FilterItem> filters)
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
        public OrConstraint<EnumAssertions<T>> Be(T value)
        {
            AddFilter(value.GetParameterName(), "=", new[] { "=" });
            return new OrConstraint<EnumAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should not has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<EnumAssertions<T>> NotBe(T value)
        {
            AddFilter(value.GetParameterName(), "!=", new[] { "!=" });
            return new AndConstraint<EnumAssertions<T>>(this);
        }
            
        #endregion
    }
}