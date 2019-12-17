using System;
using System.Collections.Generic;
using System.Linq;

namespace Confetti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents the assertions to build the nullable date time API parameter.
    /// </summary>
    public class NullableDateTimeAssertions : DateTimeAssertions
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="NullableDateTimeAssertions" /> class
        /// with the parameter name and the filters.
        /// </summary>
        /// <param name="parameterName">The parameter name.</param>
        /// <param name="filters">The filters.</param>
        internal NullableDateTimeAssertions(string parameterName, List<FilterItem> filters) 
            : base(parameterName, filters)
        {
        }
            
        #endregion

        #region Methods

        /// <summary>
        /// Asserts that a parameter should has the null value.
        /// </summary>
        /// <returns>The or constraint.</returns>
        public OrConstraint<NullableDateTimeAssertions> BeNull()
        {
            AddFilter(ParameterName, "=", new[] { "=" }, null, null);
            return new OrConstraint<NullableDateTimeAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should not has the null value.
        /// </summary>
        /// <returns>The and constraint.</returns>
        public AndConstraint<NullableDateTimeAssertions> NotBeNull()
        {
            AddFilter(ParameterName, "!=", new[] { "!=" }, null, null);
            return new AndConstraint<NullableDateTimeAssertions>(this);
        }
            
        #endregion

        #region Utilities

        private void AddFilter(string name, string @operator, string[] allowedOperators, DateTime? value, string format)
        {
            if (Filters.Any(f => f.Name == ParameterName) && (allowedOperators == null || Filters.Where(f => f.Name == ParameterName).Select(f => f.Operator).Except(allowedOperators).Any()))
                throw new ApiException(400, $"Parameter '{ParameterName}' with operator '{@operator}' doesn't support multiple operators {(allowedOperators == null ? "" : $"except: {string.Join(", ", allowedOperators)}")}.");
        
            Filters.Add(new FilterItem(ParameterName, @operator, value?.ToString(format) ?? string.Empty));
        }
            
        #endregion
    }
}