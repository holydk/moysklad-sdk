using System;
using System.Linq;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Extension methods for <see cref="Meta"/>.
    /// </summary>
    public static class MetaExtensions
    {
        #region Methods

        /// <summary>
        /// Gets the entity id from <see cref="Meta"/>.
        /// </summary>
        /// <param name="meta">The entity meta.</param>
        /// <returns>The entity id.</returns>
        public static Guid? GetId(this Meta meta)
        {
            if (meta == null)
                throw new ArgumentNullException(nameof(meta));

            if (string.IsNullOrWhiteSpace(meta.Href))
                return null;

            if (Uri.TryCreate(meta.Href, UriKind.Absolute, out var uri))
            {
                var stringGuid = string.Empty;
                if (uri.Segments?.Any() == true)
                    stringGuid = uri.Segments[uri.Segments.Length - 1];

                if (!string.IsNullOrWhiteSpace(stringGuid) && Guid.TryParse(stringGuid, out var guidId))
                    return guidId;
            }

            return null;
        }

        #endregion Methods
    }
}