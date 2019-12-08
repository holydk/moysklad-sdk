using RestSharp.Authenticators;

namespace Confetti.MoySklad.Remap.Client
{
    /// <summary>
    /// A delegate to AuthenticatorFactory method.
    /// </summary>
    /// <param name="authenticationType">The authentication type.</param>
    /// <param name="configuration">The API configuration.</param>
    /// <returns>The authenticator.</returns>
    public delegate IAuthenticator AuthenticatorFactory(string authenticationType, Configuration configuration);
}