using System.Collections.Generic;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Extensions;
using Confiti.MoySklad.Remap.Models;

namespace Confiti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents an helper class to build API parameters for <see cref="Assortment"/>.
    /// </summary>
    public class AssortmentApiParameterBuilder<T> : ApiParameterBuilder<T> where T : class
    {
        #region Fields

        private GroupBy? _groupBy;

        #endregion

        #region Methods

        /// <summary>
        /// Builds the 'groupBy' API parameter.
        /// </summary>
        /// <param name="groupBy">The group by.</param>
        public void GroupBy(GroupBy groupBy)
        {
            _groupBy = groupBy;
        }

        /// <summary>
        /// Builds the API parameters.
        /// </summary>
        /// <returns>The query.</returns>
        public override Dictionary<string, string> Build()
        {
            var query = base.Build();

            if (_groupBy.HasValue)
                query["groupBy"] = _groupBy.Value.GetParameterName();

            return query;
        }
            
        #endregion
    }
}