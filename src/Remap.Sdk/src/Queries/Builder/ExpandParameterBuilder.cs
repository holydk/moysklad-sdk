using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Extensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents the builder to prepare the expand API parameter.
    /// </summary>
    public class ExpandParameterBuilder
    {
        #region Fields

        /// <summary>
        /// Gets the orders.
        /// </summary>
        protected readonly List<string> Expanders;

        #endregion Fields

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ExpandParameterBuilder{T}" /> class
        /// with the expanders.
        /// </summary>
        /// <param name="expanders">The expanders.</param>
        public ExpandParameterBuilder(List<string> expanders)
        {
            Expanders = expanders;
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Expands the property by name.
        /// </summary>
        /// <param name="customPropertyName">The custom property name.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<ExpandParameterBuilder> With(string customPropertyName)
        {
            AddExpandParameter(customPropertyName);
            return new AndConstraint<ExpandParameterBuilder>(this);
        }

        /// <summary>
        /// Add the Expand parameter with the specified name.
        /// </summary>
        /// <param name="propertyName">The parameter name.</param>
        protected virtual void AddExpandParameter(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ApiException(400, "Property name should not be empty.");

            Expanders.Add(propertyName);
        }

        #endregion Methods
    }

    /// <summary>
    /// Represents the builder to prepare the expand API parameter for <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The concrete type of the meta entity.</typeparam>
    public class ExpandParameterBuilder<T> : ExpandParameterBuilder where T : class
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ExpandParameterBuilder{T}" /> class
        /// with the expanders.
        /// </summary>
        /// <param name="expanders">The expanders.</param>
        public ExpandParameterBuilder(List<string> expanders)
            : base(expanders)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Expands the property of the meta entity.
        /// </summary>
        /// <param name="parameter">The meta entity parameter.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<ExpandParameterBuilder<T>> With<TMember>(Expression<Func<T, TMember>> parameter) where TMember : class
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));

            AddExpandParameter(parameter.GetExpandName());
            return new AndConstraint<ExpandParameterBuilder<T>>(this);
        }

        /// <summary>
        /// Expands the property by name.
        /// </summary>
        /// <param name="customPropertyName">The custom property name.</param>
        /// <returns>The and constraint.</returns>
        public new AndConstraint<ExpandParameterBuilder<T>> With(string customPropertyName)
        {
            AddExpandParameter(customPropertyName);
            return new AndConstraint<ExpandParameterBuilder<T>>(this);
        }

        #endregion Methods
    }
}