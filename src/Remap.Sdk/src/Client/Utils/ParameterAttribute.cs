using System;

namespace Confetti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents the attribute to define the query parameter.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ParameterAttribute : Attribute
    {
        #region Properties

        /// <summary>
        /// Gets or sets the filter parameter name.
        /// </summary>
        /// <value>The filter parameter name.</value>
        public string Name { get; set; }
            
        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ParameterAttribute" /> class.
        /// </summary>
        /// <param name="name">The filter parameter name.</param>
        public ParameterAttribute(string name)
        {
            Name = name;
        }
            
        #endregion
    }
}