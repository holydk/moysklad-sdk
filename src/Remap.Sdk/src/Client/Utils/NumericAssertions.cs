using System.Collections.Generic;
using System.Linq;

namespace Confetti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents the assertions to build the numeric API parameter.
    /// </summary>
    /// <typeparam name="T">The type of the API parameter.</typeparam>
    public class NumericAssertions<T> where T: struct
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
        /// Creates a new instance of the <see cref="NumericAssertions{T}" /> class
        /// with the parameter name and the filters.
        /// </summary>
        /// <param name="parameterName">The parameter name.</param>
        /// <param name="filters">The filters.</param>
        internal NumericAssertions(string parameterName, List<FilterItem> filters)
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
        /// <returns>The or constraint.</returns>
        public OrConstraint<NumericAssertions<T>> Be(T value)
        {
            AddFilter(ParameterName, "=", new[] { "=" }, value);
            return new OrConstraint<NumericAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should not has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<NumericAssertions<T>> NotBe(T value)
        {
            AddFilter(ParameterName, "!=", new[] { "!=" }, value);
            return new AndConstraint<NumericAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be less than the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<NumericAssertions<T>> BeLessThan(T value)
        {
            AddFilter(ParameterName, "<", new[] { ">", "<=", ">=" }, value);
            return new AndConstraint<NumericAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be greater than the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<NumericAssertions<T>> BeGreaterThan(T value)
        {
            AddFilter(ParameterName, ">", new[] { "<", "<=", ">=" }, value);
            return new AndConstraint<NumericAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be less or equal to the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<NumericAssertions<T>> BeLessOrEqualTo(T value)
        {
            AddFilter(ParameterName, "<=", new[] { ">=", "<", ">" }, value);
            return new AndConstraint<NumericAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be greater or equal to the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<NumericAssertions<T>> BeGreaterOrEqualTo(T value)
        {
            AddFilter(ParameterName, ">=", new[] { "<=", "<", ">" }, value);
            return new AndConstraint<NumericAssertions<T>>(this);
        }
            
        #endregion

        #region Utilities

        private void AddFilter(string name, string @operator, string[] allowedOperators, T value)
        {
            if (Filters.Any(f => f.Name == ParameterName) && (allowedOperators == null || Filters.Where(f => f.Name == ParameterName).Select(f => f.Operator).Except(allowedOperators).Any()))
                throw new ApiException(400, $"Parameter '{ParameterName}' with operator '{@operator}' doesn't support multiple operators {(allowedOperators == null ? "" : $"except: {string.Join(", ", allowedOperators)}")}.");
        
            Filters.Add(new FilterItem(ParameterName, @operator, value.ToString()));
        }
            
        #endregion
    }
}