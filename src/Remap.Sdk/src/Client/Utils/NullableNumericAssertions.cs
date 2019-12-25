using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Confetti.MoySklad.Remap.Entities;

namespace Confetti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents the assertions to build the nullable numeric API parameter.
    /// </summary>
    /// <typeparam name="TEntity">The concrete type of the meta entity.</typeparam>
    /// <typeparam name="T">The type of the API parameter.</typeparam>
    public class NullableNumericAssertions<TEntity, T> : NumericAssertions<TEntity, T>
        where TEntity : MetaEntity 
        where T : struct
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="NullableNumericAssertions{TEntity, T}" /> class
        /// with the parameter expression and the filters.
        /// </summary>
        /// <param name="parameter">The parameter expression.</param>
        /// <param name="filters">The filters.</param>
        internal NullableNumericAssertions(Expression<Func<TEntity, T?>> parameter, List<FilterItem> filters)
            : base(parameter, filters)
        {
        }
            
        #endregion

        #region Methods

        /// <summary>
        /// Asserts that a parameter should has the null value.
        /// </summary>
        /// <returns>The or constraint.</returns>
        public OrConstraint<NullableNumericAssertions<TEntity, T>> BeNull()
        {
            AddFilter(null, "=", new[] { "=" });
            return new OrConstraint<NullableNumericAssertions<TEntity, T>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should not has the null value.
        /// </summary>
        /// <returns>The and constraint.</returns>
        public AndConstraint<NullableNumericAssertions<TEntity, T>> NotBeNull()
        {
            AddFilter(null, "!=", new[] { "!=" });
            return new AndConstraint<NullableNumericAssertions<TEntity, T>>(this);
        }
            
        #endregion
    }
}