using System.Collections.Generic;
using System.Linq;

namespace Confetti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents the assertions to build the custom API parameter.
    /// </summary>
    public class CustomAssertions
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
        /// Creates a new instance of the <see cref="CustomAssertions" /> class
        /// with the parameter name and the filters.
        /// </summary>
        /// <param name="parameterName">The parameter name.</param>
        /// <param name="filters">The filters.</param>
        internal CustomAssertions(string parameterName, List<FilterItem> filters)
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
        public OrConstraint<CustomAssertions> Be(string value)
        {
            AddFilter(ParameterName, "=", new[] { "=" }, value);
            return new OrConstraint<CustomAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should not has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<CustomAssertions> NotBe(string value)
        {
            AddFilter(ParameterName, "!=", new[] { "!=" }, value);
            return new AndConstraint<CustomAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should contains the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        public void Contains(string value)
        {
            AddFilter(ParameterName, "~", null, value);
        }

        /// <summary>
        /// Asserts that a parameter should starts with the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        public void StartsWith(string value)
        {
            AddFilter(ParameterName, "~=", null, value);
        }

        /// <summary>
        /// Asserts that a parameter should ends with the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        public void EndsWith(string value)
        {
            AddFilter(ParameterName, "=~", null, value);
        }

        /// <summary>
        /// Asserts that a parameter should be less than the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<CustomAssertions> BeLessThan(string value)
        {
            AddFilter(ParameterName, "<", new[] { ">", "<=", ">=" }, value);
            return new AndConstraint<CustomAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be greater than the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<CustomAssertions> BeGreaterThan(string value)
        {
            AddFilter(ParameterName, ">", new[] { "<", "<=", ">=" }, value);
            return new AndConstraint<CustomAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be less or equal to the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<CustomAssertions> BeLessOrEqualTo(string value)
        {
            AddFilter(ParameterName, "<=", new[] { ">=", "<", ">" }, value);
            return new AndConstraint<CustomAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be greater or equal to the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<CustomAssertions> BeGreaterOrEqualTo(string value)
        {
            AddFilter(ParameterName, ">=", new[] { "<=", "<", ">" }, value);
            return new AndConstraint<CustomAssertions>(this);
        }
            
        #endregion

        #region Utilities

        private void AddFilter(string name, string @operator, string[] allowedOperators, string value)
        {
            if (Filters.Any(f => f.Name == ParameterName) && (allowedOperators == null || Filters.Where(f => f.Name == ParameterName).Select(f => f.Operator).Except(allowedOperators).Any()))
                throw new ApiException(400, $"Parameter '{ParameterName}' with operator '{@operator}' doesn't support multiple operators {(allowedOperators == null ? "" : $"except: {string.Join(", ", allowedOperators)}")}.");
        
            Filters.Add(new FilterItem(ParameterName, @operator, value));
        }
            
        #endregion
    }
}