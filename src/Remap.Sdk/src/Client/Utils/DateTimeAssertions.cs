using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Confiti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents the assertions to build the date time API parameter.
    /// </summary>
    public class DateTimeAssertions : AbstractAssertions
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="DateTimeAssertions" /> class
        /// with the parameter expression and the filters.
        /// </summary>
        /// <param name="parameter">The parameter expression.</param>
        /// <param name="filters">The filters.</param>
        protected internal DateTimeAssertions(LambdaExpression parameter, List<FilterItem> filters)
            : base(parameter, filters)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Asserts that a parameter should has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <param name="format">The date time format.</param>
        /// <returns>The or constraint.</returns>
        public OrConstraint<DateTimeAssertions> Be(DateTime value, string format = ApiDefaults.DEFAULT_DATETIME_FORMAT)
        {
            AddFilter(value.ToString(format), "=", new[] { "=" });
            return new OrConstraint<DateTimeAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be greater or equal to the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <param name="format">The date time format.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<DateTimeAssertions> BeGreaterOrEqualTo(DateTime value, string format = ApiDefaults.DEFAULT_DATETIME_FORMAT)
        {
            AddFilter(value.ToString(format), ">=", new[] { "<=", "<", ">" });
            return new AndConstraint<DateTimeAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be greater than the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <param name="format">The date time format.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<DateTimeAssertions> BeGreaterThan(DateTime value, string format = ApiDefaults.DEFAULT_DATETIME_FORMAT)
        {
            AddFilter(value.ToString(format), ">", new[] { "<", "<=", ">=" });
            return new AndConstraint<DateTimeAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be less or equal to the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <param name="format">The date time format.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<DateTimeAssertions> BeLessOrEqualTo(DateTime value, string format = ApiDefaults.DEFAULT_DATETIME_FORMAT)
        {
            AddFilter(value.ToString(format), "<=", new[] { ">=", "<", ">" });
            return new AndConstraint<DateTimeAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be less than the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <param name="format">The date time format.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<DateTimeAssertions> BeLessThan(DateTime value, string format = ApiDefaults.DEFAULT_DATETIME_FORMAT)
        {
            AddFilter(value.ToString(format), "<", new[] { ">", "<=", ">=" });
            return new AndConstraint<DateTimeAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should not has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <param name="format">The date time format.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<DateTimeAssertions> NotBe(DateTime value, string format = ApiDefaults.DEFAULT_DATETIME_FORMAT)
        {
            AddFilter(value.ToString(format), "!=", new[] { "!=" });
            return new AndConstraint<DateTimeAssertions>(this);
        }

        #endregion Methods
    }
}