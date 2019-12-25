using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Confetti.MoySklad.Remap.Entities;

namespace Confetti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents the assertions to build the date time API parameter.
    /// </summary>
    /// <typeparam name="TEntity">The concrete type of the meta entity.</typeparam>
    public class DateTimeAssertions<TEntity> : AbstractAssertions where TEntity : MetaEntity
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="DateTimeAssertions{TEntity}" /> class
        /// with the parameter expression and the filters.
        /// </summary>
        /// <param name="parameter">The parameter expression.</param>
        /// <param name="filters">The filters.</param>
        protected internal DateTimeAssertions(LambdaExpression parameter, List<FilterItem> filters)
            : base(parameter, filters)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="DateTimeAssertions{TEntity}" /> class
        /// with the parameter expression and the filters.
        /// </summary>
        /// <param name="parameter">The parameter expression.</param>
        /// <param name="filters">The filters.</param>
        internal DateTimeAssertions(Expression<Func<TEntity, DateTime>> parameter, List<FilterItem> filters)
            : base(parameter, filters)
        {
        }
            
        #endregion

        #region Methods

        /// <summary>
        /// Asserts that a parameter should has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <param name="format">The date time format.</param>
        /// <returns>The or constraint.</returns>
        public OrConstraint<DateTimeAssertions<TEntity>> Be(DateTime value, string format = Configuration.DEFAULT_DATETIME_FORMAT)
        {
            AddFilter(value.ToString(format), "=", new[] { "=" });
            return new OrConstraint<DateTimeAssertions<TEntity>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should not has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <param name="format">The date time format.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<DateTimeAssertions<TEntity>> NotBe(DateTime value, string format = Configuration.DEFAULT_DATETIME_FORMAT)
        {
            AddFilter(value.ToString(format), "!=", new[] { "!=" });
            return new AndConstraint<DateTimeAssertions<TEntity>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be less than the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <param name="format">The date time format.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<DateTimeAssertions<TEntity>> BeLessThan(DateTime value, string format = Configuration.DEFAULT_DATETIME_FORMAT)
        {
            AddFilter(value.ToString(format), "<", new[] { ">", "<=", ">=" });
            return new AndConstraint<DateTimeAssertions<TEntity>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be greater than the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <param name="format">The date time format.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<DateTimeAssertions<TEntity>> BeGreaterThan(DateTime value, string format = Configuration.DEFAULT_DATETIME_FORMAT)
        {
            AddFilter(value.ToString(format), ">", new[] { "<", "<=", ">=" });
            return new AndConstraint<DateTimeAssertions<TEntity>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be less or equal to the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <param name="format">The date time format.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<DateTimeAssertions<TEntity>> BeLessOrEqualTo(DateTime value, string format = Configuration.DEFAULT_DATETIME_FORMAT)
        {
            AddFilter(value.ToString(format), "<=", new[] { ">=", "<", ">" });
            return new AndConstraint<DateTimeAssertions<TEntity>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should be greater or equal to the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <param name="format">The date time format.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<DateTimeAssertions<TEntity>> BeGreaterOrEqualTo(DateTime value, string format = Configuration.DEFAULT_DATETIME_FORMAT)
        {
            AddFilter(value.ToString(format), ">=", new[] { "<=", "<", ">" });
            return new AndConstraint<DateTimeAssertions<TEntity>>(this);
        }
            
        #endregion
    }
}