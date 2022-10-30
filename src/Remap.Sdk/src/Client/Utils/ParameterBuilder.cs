namespace Confiti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents an helper class to build API parameter.
    /// </summary>
    /// <typeparam name="T">The type of the API parameter assertions.</typeparam>
    public class ParameterBuilder<T>
    {
        #region Fields

        private readonly T _assertion;

        #endregion Fields

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ParameterBuilder{T}" /> class
        /// with the the API parameter assertions.
        /// </summary>
        /// <param name="assertion">The API parameter assertions.</param>
        public ParameterBuilder(T assertion)
        {
            _assertion = assertion;
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Returns the API parameter assertions.
        /// </summary>
        /// <returns>The API parameter assertions.</returns>
        public T Should()
        {
            return _assertion;
        }

        #endregion Methods
    }
}