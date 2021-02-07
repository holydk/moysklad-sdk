using System;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Extension methods for <see cref="MetaEntity"/>.
    /// </summary>
    public static class MetaEntityExtensions
    {
        #region Methods

        /// <summary>
        /// Gets the entity id.
        /// </summary>
        /// <param name="metaEntity">The meta entity.</param>
        /// <returns>The entity id.</returns>
        public static Guid? GetId(this MetaEntity metaEntity)
        {
            if (metaEntity == null)
                throw new ArgumentNullException(nameof(metaEntity));

            return metaEntity.Id ?? metaEntity.Meta?.GetId();
        }
            
        #endregion
    }
}