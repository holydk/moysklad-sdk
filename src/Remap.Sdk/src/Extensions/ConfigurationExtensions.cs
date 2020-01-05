using Confetti.MoySklad.Remap.Client;

namespace Confetti.MoySklad.Remap.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="Configuration"/>.
    /// </summary>
    public static class ConfigurationExtensions
    {
        #region Methods

        /// <summary>
        /// Gets the available authentication type.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        /// <returns>The authentication type.</returns>
        public static string GetAuthenticationType(this Configuration configuration)
        {
            if (!string.IsNullOrWhiteSpace(configuration.AccessToken))
                return "Bearer";
            if (!string.IsNullOrWhiteSpace(configuration.Username) 
                  && !string.IsNullOrWhiteSpace(configuration.Username))
                return "Basic";
            
            return null;
        }

        /// <summary>
        /// Gets the API key with prefix.
        /// </summary>
        /// <param name="configuration">The API configuration.</param>
        /// <param name="apiKeyIdentifier">The API key identifier (authentication scheme).</param>
        /// <returns>The API key with prefix.</returns>
        public static string GetApiKeyWithPrefix(this Configuration configuration, string apiKeyIdentifier)
        {
            var apiKeyValue = "";
            configuration.ApiKey.TryGetValue(apiKeyIdentifier, out apiKeyValue);
            var apiKeyPrefix = "";
            if (configuration.ApiKeyPrefix.TryGetValue(apiKeyIdentifier, out apiKeyPrefix))
                return apiKeyPrefix + " " + apiKeyValue;
            else
                return apiKeyValue;
        }
            
        #endregion
    }
}