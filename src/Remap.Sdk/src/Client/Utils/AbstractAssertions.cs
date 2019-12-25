using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Confetti.MoySklad.Remap.Extensions;

namespace Confetti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents the abstract assertions to build the API parameter.
    /// </summary>
    public abstract class AbstractAssertions
    {
        #region Properties

        /// <summary>
        /// Gets the parameter name.
        /// </summary>
        /// <value>The parameter name.</value>
        protected string ParameterName { get; }

        /// <summary>
        /// Gets the parameter filter.
        /// </summary>
        /// <value>The parameter filter.</value>
        protected FilterAttribute ParameterFilter { get; }

        /// <summary>
        /// Gets the filters.
        /// </summary>
        /// <value>The filters.</value>
        protected List<FilterItem> Filters { get; }
            
        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="AbstractAssertions" /> class
        /// with the parameter expression and the filters.
        /// </summary>
        /// <param name="parameter">The parameter expression.</param>
        /// <param name="filters">The filters.</param>
        internal AbstractAssertions(LambdaExpression parameter, List<FilterItem> filters)
            : this(parameter.GetFilterName(), filters)
        {
            ParameterFilter = parameter.GetFilter();
        }

        /// <summary>
        /// Creates a new instance of the <see cref="AbstractAssertions" /> class
        /// with the parameter expression and the filters.
        /// </summary>
        /// <param name="parameterName">The parameter name.</param>
        /// <param name="filters">The filters.</param>
        internal AbstractAssertions(string parameterName, List<FilterItem> filters)
        {
            if (string.IsNullOrWhiteSpace(parameterName))
                throw new ArgumentNullException(nameof(parameterName));

            ParameterName = parameterName;
            Filters = filters;
        }
            
        #endregion

        #region Methods

        /// <summary>
        /// Adds the filter.
        /// </summary>
        /// <param name="value">The value of the parameter.</param>
        /// <param name="operator">The operator.</param>
        /// <param name="allowedOperators">The allowed operators.</param>
        protected virtual void AddFilter(string value, string @operator, string[] allowedOperators = null)
        {
            if (!ParameterFilter.AllowNull && string.IsNullOrEmpty(value))
                throw new ApiException(400, $"Parameter '{ParameterName}' should have a value.");

            if (!ParameterFilter.AllowContinueConstraint && Filters.Any(f => f.Name == ParameterName))
                throw new ApiException(400, $"Parameter '{ParameterName}' should be specify only onсe.");

            if (Filters.Any(f => f.Name == ParameterName) && (allowedOperators == null || Filters.Where(f => f.Name == ParameterName).Select(f => f.Operator).Except(allowedOperators).Any()))
                throw new ApiException(400, $"Parameter '{ParameterName}' with operator '{@operator}' doesn't support multiple operators {(allowedOperators == null ? "" : $"except: {string.Join(", ", allowedOperators)}")}.");
        
            Filters.Add(new FilterItem(ParameterName, @operator, value));
        }
            
        #endregion
    }
}