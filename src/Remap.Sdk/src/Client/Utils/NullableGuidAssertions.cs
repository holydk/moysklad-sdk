using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Confetti.MoySklad.Remap.Entities;

namespace Confetti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents the assertions to build the nullable guid API parameter.
    /// </summary>
    /// <typeparam name="TEntity">The concrete type of the meta entity.</typeparam>
    public class NullableGuidAssertions<TEntity> : GuidAssertions<TEntity> where TEntity : MetaEntity
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="NullableGuidAssertions{TEntity}" /> class
        /// with the parameter expression and the filters.
        /// </summary>
        /// <param name="parameter">The parameter expression.</param>
        /// <param name="filters">The filters.</param>
        internal NullableGuidAssertions(Expression<Func<TEntity, Guid?>> parameter, List<FilterItem> filters)
            : base(parameter, filters)
        {
        }
            
        #endregion

        #region Methods

        /// <summary>
        /// Asserts that a parameter should has the null value.
        /// </summary>
        /// <returns>The or constraint.</returns>
        public OrConstraint<NullableGuidAssertions<TEntity>> BeNull()
        {
            AddFilter(null, "=", new[] { "=" });
            return new OrConstraint<NullableGuidAssertions<TEntity>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should not has the null value.
        /// </summary>
        /// <returns>The and constraint.</returns>
        public AndConstraint<NullableGuidAssertions<TEntity>> NotBeNull()
        {
            AddFilter(null, "!=", new[] { "!=" });
            return new AndConstraint<NullableGuidAssertions<TEntity>>(this);
        }
            
        #endregion
    }
}