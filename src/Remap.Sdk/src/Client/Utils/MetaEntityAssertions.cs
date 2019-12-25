using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Confetti.MoySklad.Remap.Entities;

namespace Confetti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents the assertions to build the API parameter for the meta entity.
    /// </summary>
    /// <typeparam name="TEntity">The concrete type of the meta entity.</typeparam>
    public class MetaEntityAssertions<TEntity> : AbstractAssertions where TEntity : MetaEntity
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="MetaEntityAssertions{TEntity}" /> class
        /// with the parameter expression and the filters.
        /// </summary>
        /// <param name="parameter">The parameter expression.</param>
        /// <param name="filters">The filters.</param>
        internal MetaEntityAssertions(Expression<Func<TEntity, MetaEntity>> parameter, List<FilterItem> filters)
            : base(parameter, filters)
        {
        }
            
        #endregion

        #region Methods

        /// <summary>
        /// Asserts that a parameter should has the value.
        /// </summary>
        /// <param name="href">The value to assert.</param>
        /// <returns>The or constraint.</returns>
        public OrConstraint<MetaEntityAssertions<TEntity>> Be(string href)
        {
            AddFilter(href, "=", new[] { "=" });
            return new OrConstraint<MetaEntityAssertions<TEntity>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should has the value.
        /// </summary>
        /// <param name="meta">The meta to assert.</param>
        /// <returns>The or constraint.</returns>
        public OrConstraint<MetaEntityAssertions<TEntity>> Be(Meta meta)
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
        public OrConstraint<MetaEntityAssertions<TEntity>> Be(MetaEntity metaEntity)
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
        public AndConstraint<MetaEntityAssertions<TEntity>> NotBe(string href)
        {
            AddFilter(href, "!=", new[] { "!=" });
            return new AndConstraint<MetaEntityAssertions<TEntity>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should not has the value.
        /// </summary>
        /// <param name="meta">The meta to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<MetaEntityAssertions<TEntity>> NotBe(Meta meta)
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
        public AndConstraint<MetaEntityAssertions<TEntity>> NotBe(MetaEntity metaEntity)
        {
            if (metaEntity == null)
                throw new ArgumentNullException(nameof(metaEntity));

            return NotBe(metaEntity.Meta);
        }
            
        #endregion
    }
}