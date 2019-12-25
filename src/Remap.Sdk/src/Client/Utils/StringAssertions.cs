using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Confetti.MoySklad.Remap.Entities;

namespace Confetti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents the assertions to build <see cref="string" /> API parameter.
    /// </summary>
    /// <typeparam name="TEntity">The concrete type of the meta entity.</typeparam>
    public class StringAssertions<TEntity> : AbstractAssertions where TEntity : MetaEntity
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="StringAssertions{TEntity}" /> class
        /// with the parameter expression and the filters.
        /// </summary>
        /// <param name="parameter">The parameter expression.</param>
        /// <param name="filters">The filters.</param>
        internal StringAssertions(Expression<Func<TEntity, string>> parameter, List<FilterItem> filters)
            : base(parameter, filters)
        {
        }
            
        #endregion

        #region Methods

        /// <summary>
        /// Asserts that a parameter should has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The or constraint.</returns>
        public OrConstraint<StringAssertions<TEntity>> Be(string value)
        {
            AddFilter(value, "=", new[] { "=" });
            return new OrConstraint<StringAssertions<TEntity>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should not has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<StringAssertions<TEntity>> NotBe(string value)
        {
            AddFilter(value, "!=", new[] { "!=" });
            return new AndConstraint<StringAssertions<TEntity>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should contains the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        public void Contains(string value)
        {
            AddFilter(value, "~", null);
        }

        /// <summary>
        /// Asserts that a parameter should starts with the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        public void StartsWith(string value)
        {
            AddFilter(value, "~=", null);
        }

        /// <summary>
        /// Asserts that a parameter should ends with the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        public void EndsWith(string value)
        {
            AddFilter(value, "=~", null);
        }
            
        #endregion
    }
}