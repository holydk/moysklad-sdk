using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Confetti.MoySklad.Remap.Entities;
using Confetti.MoySklad.Remap.Extensions;

namespace Confetti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents the builder to prepare the expand API parameter.
    /// </summary>
    /// <typeparam name="T">The concrete type of the meta entity.</typeparam>
    public class ExpandParameterBuilder<T> where T : MetaEntity
    {
        #region Fields

        /// <summary>
        /// Gets the orders.
        /// </summary>
        protected readonly List<string> Expanders;
            
        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="StringAssertions" /> class
        /// with the expanders.
        /// </summary>
        /// <param name="expanders">The expanders.</param>
        public ExpandParameterBuilder(List<string> expanders)
        {
            Expanders = expanders;
        }
            
        #endregion

        #region Methods

        /// <summary>
        /// Expands with the meta entity.
        /// </summary>
        /// <param name="parameter">The meta entity parameter.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<ExpandParameterBuilder<T>> With(Expression<Func<T, MetaEntity>> parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
                
            Expanders.Add(parameter.GetFullMemberName());
            return new AndConstraint<ExpandParameterBuilder<T>>(this);
        }
            
        #endregion
    }
}