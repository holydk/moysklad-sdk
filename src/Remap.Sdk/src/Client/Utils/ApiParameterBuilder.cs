using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Confetti.MoySklad.Remap.Entities;
using Confetti.MoySklad.Remap.Extensions;

namespace Confetti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents an helper class to build API parameters.
    /// </summary>
    /// <typeparam name="T">The concrete type of the meta entity.</typeparam>
    public class ApiParameterBuilder<T> where T : MetaEntity
    {
        #region Fields

        private string _search;
        private int? _limit;
        private int? _offset;
        private List<string> _expanders = new List<string>();
        private List<FilterItem> _filters = new List<FilterItem>();
        private Dictionary<string, OrderBy> _orders = new Dictionary<string, OrderBy>();
            
        #endregion

        #region Methods

        /// <summary>
        /// Returns <see cref="ParameterBuilder{StringAssertions}" /> to build assertions for the current <see cref="string" /> parameter.
        /// </summary>
        /// <param name="parameter">The string parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<StringAssertions<T>> Parameter(Expression<Func<T, string>> parameter)
        {
            var assertions = new StringAssertions<T>(parameter, _filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{NumericAssertions}" /> to build assertions for the current <see cref="short" /> parameter.
        /// </summary>
        /// <param name="parameter">The short parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<NumericAssertions<T, short>> Parameter(Expression<Func<T, short>> parameter)
        {
            var assertions = new NumericAssertions<T, short>(parameter, _filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{NumericAssertions}" /> to build assertions for the current <see cref="uint" /> parameter.
        /// </summary>
        /// <param name="parameter">The uint parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<NumericAssertions<T, uint>> Parameter(Expression<Func<T, uint>> parameter)
        {
            var assertions = new NumericAssertions<T, uint>(parameter, _filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{NumericAssertions}" /> to build assertions for the current <see cref="int" /> parameter.
        /// </summary>
        /// <param name="parameter">The int parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<NumericAssertions<T, int>> Parameter(Expression<Func<T, int>> parameter)
        {
            var assertions = new NumericAssertions<T, int>(parameter, _filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{NumericAssertions}" /> to build assertions for the current <see cref="float" /> parameter.
        /// </summary>
        /// <param name="parameter">The float parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<NumericAssertions<T, float>> Parameter(Expression<Func<T, float>> parameter)
        {
            var assertions = new NumericAssertions<T, float>(parameter, _filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{NumericAssertions}" /> to build assertions for the current <see cref="double" /> parameter.
        /// </summary>
        /// <param name="parameter">The double parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<NumericAssertions<T, double>> Parameter(Expression<Func<T, double>> parameter)
        {
            var assertions = new NumericAssertions<T, double>(parameter, _filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{NumericAssertions}" /> to build assertions for the current <see cref="decimal" /> parameter.
        /// </summary>
        /// <param name="parameter">The decimal parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<NumericAssertions<T, decimal>> Parameter(Expression<Func<T, decimal>> parameter)
        {
            var assertions = new NumericAssertions<T, decimal>(parameter, _filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{NullableNumericAssertions}" /> to build assertions for the current nullable <see cref="short" /> parameter.
        /// </summary>
        /// <param name="parameter">The nullable short parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<NullableNumericAssertions<T, short>> Parameter(Expression<Func<T, short?>> parameter)
        {
            var assertions = new NullableNumericAssertions<T, short>(parameter, _filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{NullableNumericAssertions}" /> to build assertions for the current nullable <see cref="uint" /> parameter.
        /// </summary>
        /// <param name="parameter">The nullable uint parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<NullableNumericAssertions<T, uint>> Parameter(Expression<Func<T, uint?>> parameter)
        {
            var assertions = new NullableNumericAssertions<T, uint>(parameter, _filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{NullableNumericAssertions}" /> to build assertions for the current nullable <see cref="int" /> parameter.
        /// </summary>
        /// <param name="parameter">The nullable int parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<NullableNumericAssertions<T, int>> Parameter(Expression<Func<T, int?>> parameter)
        {
            var assertions = new NullableNumericAssertions<T, int>(parameter, _filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{NullableNumericAssertions}" /> to build assertions for the current nullable <see cref="float" /> parameter.
        /// </summary>
        /// <param name="parameter">The nullable float parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<NullableNumericAssertions<T, float>> Parameter(Expression<Func<T, float?>> parameter)
        {
            var assertions = new NullableNumericAssertions<T, float>(parameter, _filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{NullableNumericAssertions}" /> to build assertions for the current nullable <see cref="double" /> parameter.
        /// </summary>
        /// <param name="parameter">The nullable double parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<NullableNumericAssertions<T, double>> Parameter(Expression<Func<T, double?>> parameter)
        {
            var assertions = new NullableNumericAssertions<T, double>(parameter, _filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{NullableNumericAssertions}" /> to build assertions for the current nullable <see cref="decimal" /> parameter.
        /// </summary>
        /// <param name="parameter">The nullable decimal parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<NullableNumericAssertions<T, decimal>> Parameter(Expression<Func<T, decimal?>> parameter)
        {
            var assertions = new NullableNumericAssertions<T, decimal>(parameter, _filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{DateTimeAssertions}" /> to build assertions for the current <see cref="DateTime" /> parameter.
        /// </summary>
        /// <param name="parameter">The date time parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<DateTimeAssertions<T>> Parameter(Expression<Func<T, DateTime>> parameter)
        {
            var assertions = new DateTimeAssertions<T>(parameter, _filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{NullableDateTimeAssertions}" /> to build assertions for the current nullable <see cref="DateTime" /> parameter.
        /// </summary>
        /// <param name="parameter">The nullable date time parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<NullableDateTimeAssertions<T>> Parameter(Expression<Func<T, DateTime?>> parameter)
        {
            var assertions = new NullableDateTimeAssertions<T>(parameter, _filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{BooleanAssertions}" /> to build assertions for the current <see cref="bool" /> parameter.
        /// </summary>
        /// <param name="parameter">The boolean parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<BooleanAssertions<T>> Parameter(Expression<Func<T, bool>> parameter)
        {
            var assertions = new BooleanAssertions<T>(parameter, _filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{NullableBooleanAssertions}" /> to build assertions for the current nullable <see cref="bool" /> parameter.
        /// </summary>
        /// <param name="parameter">The nullable boolean parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<NullableBooleanAssertions<T>> Parameter(Expression<Func<T, bool?>> parameter)
        {
            var assertions = new NullableBooleanAssertions<T>(parameter, _filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{MetaEntityAssertions}" /> to build assertions for the current <see cref="MetaEntity" /> parameter.
        /// </summary>
        /// <param name="parameter">The meta entity parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<MetaEntityAssertions<T>> Parameter(Expression<Func<T, MetaEntity>> parameter)
        {
            var assertions = new MetaEntityAssertions<T>(parameter, _filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{GuidAssertions}" /> to build assertions for the current <see cref="Guid" /> parameter.
        /// </summary>
        /// <param name="parameter">The guid parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<GuidAssertions<T>> Parameter(Expression<Func<T, Guid>> parameter)
        {
            var assertions = new GuidAssertions<T>(parameter, _filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{NullableGuidAssertions}" /> to build assertions for the current nullable <see cref="Guid" /> parameter.
        /// </summary>
        /// <param name="parameter">The nullable guid parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<NullableGuidAssertions<T>> Parameter(Expression<Func<T, Guid?>> parameter)
        {
            var assertions = new NullableGuidAssertions<T>(parameter, _filters);
            return Parameter(parameter, assertions);
        }

        /// <summary>
        /// Returns <see cref="ParameterBuilder{CustomAssertions}" /> to build assertions for the custom parameter.
        /// </summary>
        /// <param name="parameter">The custom parameter.</param>
        /// <returns>The parameter builder.</returns>
        public ParameterBuilder<CustomAssertions> Parameter(string parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));

            var assertions = new CustomAssertions(parameter, _filters);
            return new ParameterBuilder<CustomAssertions>(assertions);
        }

        /// <summary>
        /// Returns <see cref="ExpandParameterBuilder{T}" /> to build the expand API parameter.
        /// </summary>
        /// <returns>The expand parameter builder.</returns>
        public ExpandParameterBuilder<T> Expand()
        {
            return new ExpandParameterBuilder<T>(_expanders);
        }

        /// <summary>
        /// Returns <see cref="OrderParameterBuilder{T}" /> to build the order API parameter.
        /// </summary>
        /// <returns>The order parameter builder.</returns>
        public OrderParameterBuilder<T> Order()
        {
            return new OrderParameterBuilder<T>(_orders);
        }

        /// <summary>
        /// Builds the search API parameter.
        /// </summary>
        /// <param name="value">The search keyword(s).</param>
        public void Search(string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            _search = value;
        }

        /// <summary>
        /// Builds the limit API parameter.
        /// </summary>
        /// <param name="value">The query limit.</param>
        public void Limit(int value)
        {
            if (value < 1 || value > 1000)
                throw new ApiException(400, "Parameter 'limit' should be in range: 1-1000.");

            _limit = value;
        }

        /// <summary>
        /// Builds the offset API parameter.
        /// </summary>
        /// <param name="value">The offset in query.</param>
        public void Offset(int value)
        {
            if (value < 0)
                throw new ApiException(400, "Parameter 'offset' should be greater or equal to 0.");

            _offset = value;
        }

        /// <summary>
        /// Builds the API parameters.
        /// </summary>
        /// <returns>The query.</returns>
        public virtual Dictionary<string, string> Build()
        {
            var result = new Dictionary<string, string>();

            if (_filters.Count > 0)
                result["filter"] = string.Join(";", _filters.Select(f => $"{f.Name}{f.Operator}{f.Value}").ToArray());
            
            if (_expanders.Count > 0)
                result["expand"] = string.Join(",", _expanders);

            if (_orders.Count > 0)
                result["order"] = string.Join(";", _orders.Select(o => $"{o.Key},{o.Value.GetParameterName()}").ToArray());
            
            if (!string.IsNullOrWhiteSpace(_search))
                result["search"] = _search;

            if (_limit.HasValue)
                result["limit"] = _limit.Value.ToString();

            if (_offset.HasValue)
                result["offset"] = _offset.Value.ToString();

            return result;
        }
            
        #endregion

        #region Utilities

        private ParameterBuilder<TAssertions> Parameter<TProperty, TAssertions>(Expression<Func<T, TProperty>> parameter, TAssertions assertions)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));

            return new ParameterBuilder<TAssertions>(assertions);
        }
            
        #endregion
    }
}