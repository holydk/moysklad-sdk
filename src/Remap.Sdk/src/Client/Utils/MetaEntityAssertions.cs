using System;
using System.Collections.Generic;
using System.Linq;
using Confetti.MoySklad.Remap.Entities;

namespace Confetti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents the assertions to build the API parameter for the meta entity.
    /// </summary>
    public class MetaEntityAssertions
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
        /// Creates a new instance of the <see cref="MetaEntityAssertions" /> class
        /// with the parameter name and the filters.
        /// </summary>
        /// <param name="parameterName">The parameter name.</param>
        /// <param name="filters">The filters.</param>
        public MetaEntityAssertions(string parameterName, List<FilterItem> filters)
        {
            ParameterName = parameterName;
            Filters = filters;
        }
            
        #endregion

        #region Methods

        /// <summary>
        /// Asserts that a parameter should has the value.
        /// </summary>
        /// <param name="href">The value to assert.</param>
        /// <returns>The or constraint.</returns>
        public OrConstraint<MetaEntityAssertions> Be(string href)
        {
            AddFilter(ParameterName, "=", new[] { "=" }, href);
            return new OrConstraint<MetaEntityAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should has the value.
        /// </summary>
        /// <param name="meta">The meta to assert.</param>
        /// <returns>The or constraint.</returns>
        public OrConstraint<MetaEntityAssertions> Be(Meta meta)
        {
            if (meta == null)
                throw new ArgumentNullException(nameof(meta));

            return Be(meta.Href);
        }

        /// <summary>
        /// Asserts that a parameter should has the value.
        /// </summary>
        /// <param name="metaEntity">The meta entity to assert.</param>
        /// <returns>The or constraint.</returns>
        public OrConstraint<MetaEntityAssertions> Be(MetaEntity metaEntity)
        {
            if (metaEntity == null)
                throw new ArgumentNullException(nameof(metaEntity));

            return Be(metaEntity.Meta);
        }

        /// <summary>
        /// Asserts that a parameter should not has the value.
        /// </summary>
        /// <param name="href">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<MetaEntityAssertions> NotBe(string href)
        {
            AddFilter(ParameterName, "!=", new[] { "!=" }, href);
            return new AndConstraint<MetaEntityAssertions>(this);
        }

        /// <summary>
        /// Asserts that a parameter should not has the value.
        /// </summary>
        /// <param name="meta">The meta to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<MetaEntityAssertions> NotBe(Meta meta)
        {
            if (meta == null)
                throw new ArgumentNullException(nameof(meta));

            return NotBe(meta.Href);
        }

        /// <summary>
        /// Asserts that a parameter should not has the value.
        /// </summary>
        /// <param name="metaEntity">The meta entity to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<MetaEntityAssertions> NotBe(MetaEntity metaEntity)
        {
            if (metaEntity == null)
                throw new ArgumentNullException(nameof(metaEntity));

            return NotBe(metaEntity.Meta);
        }
            
        #endregion

        #region Utilities

        private void AddFilter(string name, string @operator, string[] allowedOperators, string href)
        {
            if (Filters.Any(f => f.Name == ParameterName) && (allowedOperators == null || Filters.Where(f => f.Name == ParameterName).Select(f => f.Operator).Except(allowedOperators).Any()))
                throw new ApiException(400, $"Parameter '{ParameterName}' with operator '{@operator}' doesn't support multiple operators {(allowedOperators == null ? "" : $"except: {string.Join(", ", allowedOperators)}")}.");
        
            Filters.Add(new FilterItem(ParameterName, @operator, href.ToString()));
        }
            
        #endregion
    }
}