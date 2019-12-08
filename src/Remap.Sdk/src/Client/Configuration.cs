using System.Collections.Generic;
using System.IO;
using RestSharp.Authenticators;

namespace Confetti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents the API configuration settings.
    /// </summary>
    public class Configuration
    {
        #region Fields

        private const int DEFAULT_TIMEOUT = 100000;
        private const string DEFAULT_DATETIME_FORMAT = "yyyy-MM-dd HH:mm:ss";

        private string _dateTimeFormat = DEFAULT_DATETIME_FORMAT;
        private string _tempFolderPath;

        /// <summary>
        /// The default Configuration.
        /// </summary>
        public static Configuration Default = new Configuration();

        /// <summary>
        /// Default creation of exceptions for a given method name and response object.
        /// </summary>
        public static readonly ExceptionFactory DefaultExceptionFactory = (methodName, response) =>
        {
            int status = (int)response.StatusCode;
            // https://dev.moysklad.ru/doc/api/remap/1.2/#mojsklad-json-api-obschie-swedeniq-obrabotka-oshibok
            if (status == 301 || status == 303 || status >= 400)
                return new ApiException(status, $"Error calling {methodName}: {response.Content}", response.Content);
            if (status == 0)
                return new ApiException(status, $"Error calling {methodName}: {response.ErrorMessage}", response.ErrorMessage);
            
            return null;
        };

        /// <summary>
        /// Default creation of <see cref="IAuthenticator"/>'s for a given API configuration.
        /// </summary>
        /// <returns>The http request authenticator.</returns>
        public static readonly AuthenticatorFactory DefaultAuthenticatorFactory = (authenticationType, configuration) =>
        {
            if (authenticationType == null)
                return null;

            if (authenticationType.Equals("Basic", System.StringComparison.OrdinalIgnoreCase))
                return new HttpBasicAuthenticator(configuration.Username, configuration.Password);
            if (authenticationType.Equals("Bearer", System.StringComparison.OrdinalIgnoreCase))
                return new JwtAuthenticator(configuration.AccessToken);

            return null;
        };

        /// <summary>
        /// The version of the package.
        /// </summary>
        public const string Version = "0.2.0";
            
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the HTTP user agent.
        /// </summary>
        /// <value>The http user agent.</value>
        public string UserAgent { get; set; }

        /// <summary>
        /// Gets or sets the username (HTTP basic authentication).
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password (HTTP basic authentication).
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the access token for OAuth2 authentication.
        /// </summary>
        /// <value>The access token.</value>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the default API client for making HTTP calls.
        /// </summary>
        /// <value>The API client.</value>
        public ApiClient ApiClient { get; set; }

        /// <summary>
        /// Gets or sets the authenticator for http requests.
        /// </summary>
        /// <value></value>
        public IAuthenticator Authenticator { get; set; }

        /// <summary>
        /// Gets or sets the default headers.
        /// </summary>
        /// <value>The default headers.</value>
        public Dictionary<string, string> DefaultHeaders { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Gets or sets the API key based on the authentication name.
        /// </summary>
        /// <value>The API key.</value>
        public Dictionary<string, string> ApiKey { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Gets or sets the prefix (e.g. Token) of the API key based on the authentication name.
        /// </summary>
        /// <value>The prefix of the API key.</value>
        public Dictionary<string, string> ApiKeyPrefix { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Gets or sets the HTTP timeout (milliseconds) of ApiClient. Default to 100000 milliseconds.
        /// </summary>
        /// <value>The timeout.</value>
        public int Timeout
        {
            get 
            { 
                return ApiClient.RestClient.Timeout; 
            }
            set
            {
                if (ApiClient != null)
                    ApiClient.RestClient.Timeout = value;
            }
        }

        /// <summary>
        /// Gets or sets the the date time format used when serializing in the <see cref="ApiClient"/>.
        /// By default, it's set to yyyy-MM-dd HH:mm:ss, for others see:
        /// https://dev.moysklad.ru/doc/api/remap/1.2/#mojsklad-json-api-obschie-swedeniq-format-daty-i-wremeni
        /// No validation is done to ensure that the string you're providing is valid.
        /// </summary>
        /// <value>The DateTimeFormat string</value>
        public string DateTimeFormat
        {
            get
            {
                return _dateTimeFormat;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    // Never allow a blank or null string, go back to the default
                    _dateTimeFormat = DEFAULT_DATETIME_FORMAT;
                    return;
                }

                // Caution, no validation when you choose date time format other than yyyy-MM-dd HH:mm:ss
                // Take a look at the above links
                _dateTimeFormat = value;
            }
        }

        /// <summary>
        /// Gets or sets the temporary folder path to store the files downloaded from the server.
        /// </summary>
        /// <value>The folder path.</value>
        public string TempFolderPath
        {
            get 
            { 
                return _tempFolderPath; 
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _tempFolderPath = value;
                    return;
                }

                // create the directory if it does not exist
                if (!Directory.Exists(value))
                    Directory.CreateDirectory(value);

                // check if the path contains directory separator at the end
                if (value[value.Length - 1] == Path.DirectorySeparatorChar)
                    _tempFolderPath = value;
                else
                    _tempFolderPath = value  + Path.DirectorySeparatorChar;
            }
        }
            
        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="Configuration" /> class
        /// with API client or uses the default API client if not specified.
        /// </summary>
        /// <param name="apiClient">The API client.</param>
        public Configuration(ApiClient apiClient = null)
        {
            SetApiClient(apiClient);

            Timeout = DEFAULT_TIMEOUT;
            UserAgent = $"Confetti-Remap-Sdk\\{Version}";
        }
            
        #endregion

        #region Methods

        /// <summary>
        /// Adds the default header to configuration.
        /// </summary>
        /// <param name="key">The header field name.</param>
        /// <param name="value">The header field value.</param>
        public void AddDefaultHeader(string key, string value)
        {
            DefaultHeaders[key] = value;
        }

        /// <summary>
        /// Adds the API key header.
        /// </summary>
        /// <param name="key">The API key name.</param>
        /// <param name="value">The API key value.</param>
        public void AddApiKey(string key, string value)
        {
            ApiKey[key] = value;
        }

        /// <summary>
        /// Adds the API key prefix.
        /// </summary>
        /// <param name="key">The API key name.</param>
        /// <param name="value">The API key value.</param>
        public void AddApiKeyPrefix(string key, string value)
        {
            ApiKeyPrefix[key] = value;
        }

        /// <summary>
        /// Sets the API client or uses the default API client if not specified.
        /// </summary>
        /// <param name="apiClient">The API client.</param>
        public void SetApiClient(ApiClient apiClient = null)
        {
            if (apiClient == null)
            {
                if (Default != null && Default.ApiClient == null)
                    Default.ApiClient = new ApiClient();

                ApiClient = Default != null ? Default.ApiClient : new ApiClient();
            }
            else
            {
                if (Default != null && Default.ApiClient == null)
                    Default.ApiClient = apiClient;

                ApiClient = apiClient;
            }
        }
            
        #endregion
    }
}