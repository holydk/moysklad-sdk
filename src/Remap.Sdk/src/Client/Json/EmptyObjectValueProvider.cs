using System.Linq;
using Newtonsoft.Json.Serialization;

namespace Confiti.MoySklad.Remap.Client.Json
{
    /// <summary>
    /// This decorates the real the value provider to detect
    /// the empty object (All object members are null).
    /// Used to fix serialized nested null fields (e.g. '{ "foo": null }').
    /// </summary>
    public class EmptyObjectValueProvider : IValueProvider
    {
        #region Fields

        private readonly IValueProvider _innerProvider;

        #endregion Fields

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="EmptyObjectValueProvider" /> class.
        /// </summary>
        /// <param name="innerProvider">The inner value provider.</param>
        public EmptyObjectValueProvider(IValueProvider innerProvider)
        {
            _innerProvider = innerProvider;
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="target">The target to get the value from.</param>
        /// <returns>The value.</returns>
        public object GetValue(object target)
        {
            var val = _innerProvider.GetValue(target);
            if (val == null)
                return null;

            if (val?.GetType().GetProperties().All(p => p.GetValue(val) == null) ?? false)
                return "{}";

            return val;
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="target">The target to set the value on.</param>
        /// <param name="value">The value to set on the target.</param>
        public void SetValue(object target, object value)
        {
            _innerProvider.SetValue(target, value);
        }

        #endregion Methods
    }
}