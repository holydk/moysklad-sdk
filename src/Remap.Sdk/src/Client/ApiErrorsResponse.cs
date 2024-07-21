namespace Confiti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents a response containing the <see cref="ApiError"/>'s.
    /// </summary>
    public sealed class ApiErrorsResponse
    {
        #region Properties

        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>The errors.</value>
        public ApiError[] Errors { get; set; }

        #endregion Properties
    }
}