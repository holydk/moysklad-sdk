namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents the order by enum.
    /// </summary>
    public enum OrderBy
    {
        /// <summary>
        /// Order by Asc.
        /// </summary>
        [Parameter("asc")]
        Asc,

        /// <summary>
        /// Order by Desc.
        /// </summary>
        [Parameter("desc")]
        Desc
    }
}