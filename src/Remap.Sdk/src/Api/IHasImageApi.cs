namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents an abstraction containing the image API.
    /// </summary>
    internal interface IHasImageApi
    {
        /// <summary>
        /// Gets the API to interact with the image endpoint.
        /// </summary>
        ImageApi Images { get; }
    }
}