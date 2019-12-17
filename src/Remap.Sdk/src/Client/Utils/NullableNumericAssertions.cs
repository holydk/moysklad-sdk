using System.Collections.Generic;
using System.Linq;

namespace Confetti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents the assertions to build the nullable numeric API parameter.
    /// </summary>
    /// <typeparam name="T">The type of the API parameter.</typeparam>
    public class NullableNumericAssertions<T> : NumericAssertions<T> where T: struct
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="NullableNumericAssertions{T}" /> class
        /// with the parameter name and the filters.
        /// </summary>
        /// <param name="parameterName">The parameter name.</param>
        /// <param name="filters">The filters.</param>
        internal NullableNumericAssertions(string parameterName, List<FilterItem> filters) 
            : base(parameterName, filters)
        {
        }
            
        #endregion

        #region Methods

        /// <summary>
        /// Asserts that a parameter should has the null value.
        /// </summary>
        /// <returns>The or constraint.</returns>
        public OrConstraint<NumericAssertions<T>> BeNull()
        {
            AddFilter(ParameterName, "=", new[] { "=" }, null);
            return new OrConstraint<NumericAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should not has the null value.
        /// </summary>
        /// <returns>The and constraint.</returns>
        public AndConstraint<NumericAssertions<T>> NotBeNull()
        {
            AddFilter(ParameterName, "!=", new[] { "!=" }, null);
            return new AndConstraint<NumericAssertions<T>>(this);
        }
            
        #endregion

        #region Utilities

        private void AddFilter(string name, string @operator, string[] allowedOperators, T? value)
        {
            if (Filters.Any(f => f.Name == ParameterName) && (allowedOperators == null || Filters.Where(f => f.Name == ParameterName).Select(f => f.Operator).Except(allowedOperators).Any()))
                throw new ApiException(400, $"Parameter '{ParameterName}' with operator '{@operator}' doesn't support multiple operators {(allowedOperators == null ? "" : $"except: {string.Join(", ", allowedOperators)}")}.");
        
            Filters.Add(new FilterItem(ParameterName, @operator, value?.ToString() ?? string.Empty));
        }
            
        #endregion
    }
}