using Confiti.MoySklad.Remap.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents the assertions to build the API parameter for the meta entity.
    /// </summary>
    public class MetaEntityAssertions : AbstractAssertions
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="MetaEntityAssertions" /> class
        /// with the parameter expression and the filters.
        /// </summary>
        /// <param name="parameter">The parameter expression.</param>
        /// <param name="filters">The filters.</param>
        internal MetaEntityAssertions(LambdaExpression parameter, List<FilterItem> filters)
            : base(parameter, filters)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="MetaEntityAssertions" /> class
        /// with the parameter expression, filter attribute and the filters.
        /// </summary>
        /// <param name="parameterName">The parameter name.</param>
        /// <param name="filterAttribute">The filter attribute.</param>
        /// <param name="filters">The filters.</param>
        internal MetaEntityAssertions(string parameterName, FilterAttribute filterAttribute, List<FilterItem> filters)
            : base(parameterName, filterAttribute, filters)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Asserts that a parameter should has the value.
        /// </summary>
        /// <param name="href">The value to assert.</param>
        /// <returns>The or constraint.</returns>
        public OrConstraint<MetaEntityAssertions> Be(string href)
        {
            AddFilter(href, "=", new[] { "=" });
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
            AddFilter(href, "!=", new[] { "!=" });
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

        #endregion Methods
    }
}