namespace Confiti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents the MoySklad credentials.
    /// </summary>
    public class MoySkladCredentials
    {
        #region Properties

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
        /// Gets or sets the access token (Bearer authentication).
        /// </summary>
        /// <value>The access token.</value>
        public string AccessToken { get; set; }

        #endregion
    }
}