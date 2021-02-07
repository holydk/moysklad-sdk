namespace Confiti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents the configuration aspects required to interact with the API endpoint.
    /// </summary>
    public interface IApiAccessor
    {
        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path.</value>
        string BasePath { get; }

        /// <summary>
        /// Gets the relative path to the endpoint.
        /// </summary>
        /// <value>The relative path.</value>
        string Path { get; }

         /// <summary>
        /// Gets or sets the <see cref="Configuration"/>.
        /// </summary>
        /// <value>The API configuration.</value>
        Configuration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        ExceptionFactory ExceptionFactory { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of authenticator.
        /// </summary>
        AuthenticatorFactory AuthenticatorFactory { get; set; }
    }
}