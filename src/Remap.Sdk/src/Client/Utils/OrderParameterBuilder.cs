using Confiti.MoySklad.Remap.Extensions;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Confiti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents the assertions to build the order API parameter.
    /// </summary>
    public class OrderParameterBuilder
    {
        #region Fields

        /// <summary>
        /// Gets the orders.
        /// </summary>
        protected readonly Dictionary<string, OrderBy> Orders;

        #endregion Fields

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="OrderParameterBuilder" /> class
        /// with the orders.
        /// </summary>
        /// <param name="orders">The orders.</param>
        public OrderParameterBuilder(Dictionary<string, OrderBy> orders)
        {
            Orders = orders;
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Order by the custom property name.
        /// </summary>
        /// <param name="customPropertyName">The custom property name.</param>
        /// <param name="orderBy">The order action.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<OrderParameterBuilder> By(string customPropertyName, OrderBy orderBy = OrderBy.Asc)
        {
            AddOrderParameter(customPropertyName, orderBy);
            return new AndConstraint<OrderParameterBuilder>(this);
        }

        /// <summary>
        /// Add the Order parameter with the specified name.
        /// </summary>
        /// <param name="propertyName">The parameter name.</param>
        /// <param name="orderBy">The order action.</param>
        protected virtual void AddOrderParameter(string propertyName, OrderBy orderBy)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ApiException(400, "Property name should not be empty.");

            Orders[propertyName] = orderBy;
        }

        #endregion Methods
    }

    /// <summary>
    /// Represents the assertions to build the order API parameter for <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The concrete type of the meta entity.</typeparam>
    public class OrderParameterBuilder<T> : OrderParameterBuilder where T : class
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="OrderParameterBuilder{T}" /> class
        /// with the orders.
        /// </summary>
        /// <param name="orders">The orders.</param>
        public OrderParameterBuilder(Dictionary<string, OrderBy> orders)
            : base(orders)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Order by the string property of parameter.
        /// </summary>
        /// <param name="parameter">The string parameter.</param>
        /// <param name="orderBy">The order action.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<OrderParameterBuilder<T>> By(Expression<Func<T, string>> parameter, OrderBy orderBy = OrderBy.Asc)
        {
            return By<string>(parameter, orderBy);
        }

        /// <summary>
        /// Order by the short property of parameter.
        /// </summary>
        /// <param name="parameter">The short parameter.</param>
        /// <param name="orderBy">The order action.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<OrderParameterBuilder<T>> By(Expression<Func<T, short>> parameter, OrderBy orderBy = OrderBy.Asc)
        {
            return By<short>(parameter, orderBy);
        }

        /// <summary>
        /// Order by the uint property of parameter.
        /// </summary>
        /// <param name="parameter">The uint parameter.</param>
        /// <param name="orderBy">The order action.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<OrderParameterBuilder<T>> By(Expression<Func<T, uint>> parameter, OrderBy orderBy = OrderBy.Asc)
        {
            return By<uint>(parameter, orderBy);
        }

        /// <summary>
        /// Order by the int property of parameter.
        /// </summary>
        /// <param name="parameter">The int parameter.</param>
        /// <param name="orderBy">The order action.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<OrderParameterBuilder<T>> By(Expression<Func<T, int>> parameter, OrderBy orderBy = OrderBy.Asc)
        {
            return By<int>(parameter, orderBy);
        }

        /// <summary>
        /// Order by the float property of parameter.
        /// </summary>
        /// <param name="parameter">The float parameter.</param>
        /// <param name="orderBy">The order action.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<OrderParameterBuilder<T>> By(Expression<Func<T, float>> parameter, OrderBy orderBy = OrderBy.Asc)
        {
            return By<float>(parameter, orderBy);
        }

        /// <summary>
        /// Order by the double property of parameter.
        /// </summary>
        /// <param name="parameter">The double parameter.</param>
        /// <param name="orderBy">The order action.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<OrderParameterBuilder<T>> By(Expression<Func<T, double>> parameter, OrderBy orderBy = OrderBy.Asc)
        {
            return By<double>(parameter, orderBy);
        }

        /// <summary>
        /// Order by the decimal property of parameter.
        /// </summary>
        /// <param name="parameter">The decimal parameter.</param>
        /// <param name="orderBy">The order action.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<OrderParameterBuilder<T>> By(Expression<Func<T, decimal>> parameter, OrderBy orderBy = OrderBy.Asc)
        {
            return By<decimal>(parameter, orderBy);
        }

        /// <summary>
        /// Order by the nullable short property of parameter.
        /// </summary>
        /// <param name="parameter">The nullable short parameter.</param>
        /// <param name="orderBy">The order action.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<OrderParameterBuilder<T>> By(Expression<Func<T, short?>> parameter, OrderBy orderBy = OrderBy.Asc)
        {
            return By<short?>(parameter, orderBy);
        }

        /// <summary>
        /// Order by the nullable uint property of parameter.
        /// </summary>
        /// <param name="parameter">The nullable uint parameter.</param>
        /// <param name="orderBy">The order action.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<OrderParameterBuilder<T>> By(Expression<Func<T, uint?>> parameter, OrderBy orderBy = OrderBy.Asc)
        {
            return By<uint?>(parameter, orderBy);
        }

        /// <summary>
        /// Order by the nullable int property of parameter.
        /// </summary>
        /// <param name="parameter">The nullable int parameter.</param>
        /// <param name="orderBy">The order action.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<OrderParameterBuilder<T>> By(Expression<Func<T, int?>> parameter, OrderBy orderBy = OrderBy.Asc)
        {
            return By<int?>(parameter, orderBy);
        }

        /// <summary>
        /// Order by the nullable float property of parameter.
        /// </summary>
        /// <param name="parameter">The nullable float parameter.</param>
        /// <param name="orderBy">The order action.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<OrderParameterBuilder<T>> By(Expression<Func<T, float?>> parameter, OrderBy orderBy = OrderBy.Asc)
        {
            return By<float?>(parameter, orderBy);
        }

        /// <summary>
        /// Order by the nullable double property of parameter.
        /// </summary>
        /// <param name="parameter">The nullable double parameter.</param>
        /// <param name="orderBy">The order action.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<OrderParameterBuilder<T>> By(Expression<Func<T, double?>> parameter, OrderBy orderBy = OrderBy.Asc)
        {
            return By<double?>(parameter, orderBy);
        }

        /// <summary>
        /// Order by the nullable decimal property of parameter.
        /// </summary>
        /// <param name="parameter">The nullable decimal parameter.</param>
        /// <param name="orderBy">The order action.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<OrderParameterBuilder<T>> By(Expression<Func<T, decimal?>> parameter, OrderBy orderBy = OrderBy.Asc)
        {
            return By<decimal?>(parameter, orderBy);
        }

        /// <summary>
        /// Order by the nullable boolean property of parameter.
        /// </summary>
        /// <param name="parameter">The boolean parameter.</param>
        /// <param name="orderBy">The order action.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<OrderParameterBuilder<T>> By(Expression<Func<T, bool>> parameter, OrderBy orderBy = OrderBy.Asc)
        {
            return By<bool>(parameter, orderBy);
        }

        /// <summary>
        /// Order by the nullable boolean property of parameter.
        /// </summary>
        /// <param name="parameter">The nullable boolean parameter.</param>
        /// <param name="orderBy">The order action.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<OrderParameterBuilder<T>> By(Expression<Func<T, bool?>> parameter, OrderBy orderBy = OrderBy.Asc)
        {
            return By<bool?>(parameter, orderBy);
        }

        /// <summary>
        /// Order by the date time property of parameter.
        /// </summary>
        /// <param name="parameter">The date time parameter.</param>
        /// <param name="orderBy">The order action.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<OrderParameterBuilder<T>> By(Expression<Func<T, DateTime>> parameter, OrderBy orderBy = OrderBy.Asc)
        {
            return By<DateTime>(parameter, orderBy);
        }

        /// <summary>
        /// Order by the nullable date time property of parameter.
        /// </summary>
        /// <param name="parameter">The nullable date time parameter.</param>
        /// <param name="orderBy">The order action.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<OrderParameterBuilder<T>> By(Expression<Func<T, DateTime?>> parameter, OrderBy orderBy = OrderBy.Asc)
        {
            return By<DateTime?>(parameter, orderBy);
        }

        /// <summary>
        /// Order by the guid property of parameter.
        /// </summary>
        /// <param name="parameter">The guid parameter.</param>
        /// <param name="orderBy">The order action.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<OrderParameterBuilder<T>> By(Expression<Func<T, Guid>> parameter, OrderBy orderBy = OrderBy.Asc)
        {
            return By<Guid>(parameter, orderBy);
        }

        /// <summary>
        /// Order by the nullable guid property of parameter.
        /// </summary>
        /// <param name="parameter">The nullable guid parameter.</param>
        /// <param name="orderBy">The order action.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<OrderParameterBuilder<T>> By(Expression<Func<T, Guid?>> parameter, OrderBy orderBy = OrderBy.Asc)
        {
            return By<Guid?>(parameter, orderBy);
        }

        /// <summary>
        /// Order by the custom property name.
        /// </summary>
        /// <param name="customPropertyName">The custom property name.</param>
        /// <param name="orderBy">The order action.</param>
        /// <returns>The and constraint.</returns>
        public new AndConstraint<OrderParameterBuilder<T>> By(string customPropertyName, OrderBy orderBy = OrderBy.Asc)
        {
            AddOrderParameter(customPropertyName, orderBy);
            return new AndConstraint<OrderParameterBuilder<T>>(this);
        }

        #endregion Methods

        #region Utilities

        /// <summary>
        /// Order by the property of parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <param name="orderBy">The order action.</param>
        /// <typeparam name="TProperty">The type of property.</typeparam>
        /// <returns>The and constraint.</returns>
        private AndConstraint<OrderParameterBuilder<T>> By<TProperty>(Expression<Func<T, TProperty>> parameter, OrderBy orderBy)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));

            if (!parameter.IsAllowOrder())
                throw new ApiException(400, $"Order isn't allowed for the '{parameter.GetParameterName()}'.");

            if (parameter.GetNestingLevel() > 1)
                throw new ApiException(400, $"Parameter nesting level should be 1.");

            AddOrderParameter(parameter.GetParameterName(), orderBy);

            return new AndConstraint<OrderParameterBuilder<T>>(this);
        }

        #endregion Utilities
    }
}