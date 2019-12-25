using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Confetti.MoySklad.Remap.Entities;

namespace Confetti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents the assertions to build the numeric API parameter.
    /// </summary>
    /// <typeparam name="TEntity">The concrete type of the meta entity.</typeparam>
    /// <typeparam name="T">The type of the API parameter.</typeparam>
    public class NumericAssertions<TEntity, T> : AbstractAssertions
        where TEntity : MetaEntity 
        where T : struct
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="NumericAssertions{TEntity, T}" /> class
        /// with the parameter expression and the filters.
        /// </summary>
        /// <param name="parameter">The parameter expression.</param>
        /// <param name="filters">The filters.</param>
        internal NumericAssertions(LambdaExpression parameter, List<FilterItem> filters)
            : base(parameter, filters)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="NumericAssertions{TEntity, T}" /> class
        /// with the parameter expression and the filters.
        /// </summary>
        /// <param name="parameter">The parameter expression.</param>
        /// <param name="filters">The filters.</param>
        internal NumericAssertions(Expression<Func<TEntity, T>> parameter, List<FilterItem> filters)
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
        public OrConstraint<NumericAssertions<TEntity, T>> Be(T value)
        {
            AddFilter(value.ToString(), "=", new[] { "=" });
            return new OrConstraint<NumericAssertions<TEntity, T>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should not has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<NumericAssertions<TEntity, T>> NotBe(T value)
        {
            AddFilter(value.ToString(), "!=", new[] { "!=" });
            return new AndConstraint<NumericAssertions<TEntity, T>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be less than the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<NumericAssertions<TEntity, T>> BeLessThan(T value)
        {
            AddFilter(value.ToString(), "<", new[] { ">", "<=", ">=" });
            return new AndConstraint<NumericAssertions<TEntity, T>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be greater than the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<NumericAssertions<TEntity, T>> BeGreaterThan(T value)
        {
            AddFilter(value.ToString(), ">", new[] { "<", "<=", ">=" });
            return new AndConstraint<NumericAssertions<TEntity, T>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be less or equal to the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<NumericAssertions<TEntity, T>> BeLessOrEqualTo(T value)
        {
            AddFilter(value.ToString(), "<=", new[] { ">=", "<", ">" });
            return new AndConstraint<NumericAssertions<TEntity, T>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be greater or equal to the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<NumericAssertions<TEntity, T>> BeGreaterOrEqualTo(T value)
        {
            AddFilter(value.ToString(), ">=", new[] { "<=", "<", ">" });
            return new AndConstraint<NumericAssertions<TEntity, T>>(this);
        }
            
        #endregion
    }
}