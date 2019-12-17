using System;
using System.Collections.Generic;
using System.Linq;

namespace Confetti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents the assertions to build the date time API parameter.
    /// </summary>
    public class DateTimeAssertions
    {
        #region Fields

        /// <summary>
        /// Gets the parameter name.
        /// </summary>
        protected readonly string ParameterName;

        /// <summary>
        /// Gets the filters.
        /// </summary>
        protected readonly List<FilterItem> Filters;
            
        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="DateTimeAssertions" /> class
        /// with the parameter name and the filters.
        /// </summary>
        /// <param name="parameterName">The parameter name.</param>
        /// <param name="filters">The filters.</param>
        internal DateTimeAssertions(string parameterName, List<FilterItem> filters)
        {
            ParameterName = parameterName;
            Filters = filters;
        }
            
        #endregion

        #region Methods

        /// <summary>
        /// Asserts that a parameter should has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <param name="format">The date time format.</param>
        /// <returns>The or constraint.</returns>
        public OrConstraint<DateTimeAssertions> Be(DateTime value, string format = Configuration.DEFAULT_DATETIME_FORMAT)
        {
            AddFilter(ParameterName, "=", new[] { "=" }, value, format);
            return new OrConstraint<DateTimeAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should not has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <param name="format">The date time format.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<DateTimeAssertions> NotBe(DateTime value, string format = Configuration.DEFAULT_DATETIME_FORMAT)
        {
            AddFilter(ParameterName, "!=", new[] { "!=" }, value, format);
            return new AndConstraint<DateTimeAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be less than the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <param name="format">The date time format.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<DateTimeAssertions> BeLessThan(DateTime value, string format = Configuration.DEFAULT_DATETIME_FORMAT)
        {
            AddFilter(ParameterName, "<", new[] { ">", "<=", ">=" }, value, format);
            return new AndConstraint<DateTimeAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be greater than the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <param name="format">The date time format.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<DateTimeAssertions> BeGreaterThan(DateTime value, string format = Configuration.DEFAULT_DATETIME_FORMAT)
        {
            AddFilter(ParameterName, ">", new[] { "<", "<=", ">=" }, value, format);
            return new AndConstraint<DateTimeAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be less or equal to the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <param name="format">The date time format.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<DateTimeAssertions> BeLessOrEqualTo(DateTime value, string format = Configuration.DEFAULT_DATETIME_FORMAT)
        {
            AddFilter(ParameterName, "<=", new[] { ">=", "<", ">" }, value, format);
            return new AndConstraint<DateTimeAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be greater or equal to the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <param name="format">The date time format.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<DateTimeAssertions> BeGreaterOrEqualTo(DateTime value, string format = Configuration.DEFAULT_DATETIME_FORMAT)
        {
            AddFilter(ParameterName, ">=", new[] { "<=", "<", ">" }, value, format);
            return new AndConstraint<DateTimeAssertions>(this);
        }
            
        #endregion

        #region Utilities

        private void AddFilter(string name, string @operator, string[] allowedOperators, DateTime value, string format)
        {
            if (Filters.Any(f => f.Name == ParameterName) && (allowedOperators == null || Filters.Where(f => f.Name == ParameterName).Select(f => f.Operator).Except(allowedOperators).Any()))
                throw new ApiException(400, $"Parameter '{ParameterName}' with operator '{@operator}' doesn't support multiple operators {(allowedOperators == null ? "" : $"except: {string.Join(", ", allowedOperators)}")}.");
        
            Filters.Add(new FilterItem(ParameterName, @operator, value.ToString(format)));
        }
            
        #endregion
    }
}