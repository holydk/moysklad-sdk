using Confiti.MoySklad.Remap.Client;

namespace Confiti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents a group by parameter for the assortment request.
    /// </summary>
    public enum GroupBy
    {
        /// <summary>
        /// Uses to get only products.
        /// </summary>
        [Parameter("product")]
        Product,

        /// <summary>
        /// Uses to get products and modifications.
        /// </summary>
        [Parameter("variant")]
        Variant,

        /// <summary>
        /// Uses to get all entities.
        /// </summary>
        [Parameter("consignment")]
        Consignment
    }
}