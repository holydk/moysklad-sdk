using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Confetti.MoySklad.Remap.Entities;

namespace Confetti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents the assertions to build the nullable date time API parameter.
    /// </summary>
    /// <typeparam name="TEntity">The concrete type of the meta entity.</typeparam>
    public class NullableDateTimeAssertions<TEntity> : DateTimeAssertions<TEntity> where TEntity : MetaEntity
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="NullableDateTimeAssertions{TEntity}" /> class
        /// with the parameter expression and the filters.
        /// </summary>
        /// <param name="parameter">The parameter expression.</param>
        /// <param name="filters">The filters.</param>
        internal NullableDateTimeAssertions(Expression<Func<TEntity, DateTime?>> parameter, List<FilterItem> filters)
            : base(parameter, filters)
        {
        }
            
        #endregion

        #region Methods

        /// <summary>
        /// Asserts that a parameter should has the null value.
        /// </summary>
        /// <returns>The or constraint.</returns>
        public OrConstraint<NullableDateTimeAssertions<TEntity>> BeNull()
        {
            AddFilter(null, "=", new[] { "=" });
            return new OrConstraint<NullableDateTimeAssertions<TEntity>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should not has the null value.
        /// </summary>
        /// <returns>The and constraint.</returns>
        public AndConstraint<NullableDateTimeAssertions<TEntity>> NotBeNull()
        {
            AddFilter(null, "!=", new[] { "!=" });
            return new AndConstraint<NullableDateTimeAssertions<TEntity>>(this);
        }
            
        #endregion
    }
}