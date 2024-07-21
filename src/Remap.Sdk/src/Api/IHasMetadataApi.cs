using Confiti.MoySklad.Remap.Client;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents an abstraction containing the metadata API.
    /// </summary>
    /// <typeparam name="TApi">The type of the <see cref="MetadataApi{TEntity}"/> or <see cref="MetadataApi{TEntity, TQuery}"/>.</typeparam>
    internal interface IHasMetadataApi<out TApi> where TApi : ApiAccessor
    {
        /// <summary>
        /// Gets the API to interact with the metadata endpoint.
        /// </summary>
        TApi Metadata { get; }
    }
}