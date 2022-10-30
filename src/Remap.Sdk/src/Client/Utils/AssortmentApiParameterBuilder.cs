using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Extensions;
using Confiti.MoySklad.Remap.Models;
using System.Collections.Generic;

namespace Confiti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents an helper class to build API parameters for <see cref="Assortment"/>.
    /// </summary>
    public class AssortmentApiParameterBuilder : ApiParameterBuilder<AssortmentQuery>
    {
        #region Fields

        private GroupBy? _groupBy;

        #endregion Fields

        #region Methods

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

        /// <summary>
        /// Builds the 'groupBy' API parameter.
        /// </summary>
        /// <param name="groupBy">The group by.</param>
        public void GroupBy(GroupBy groupBy)
        {
            _groupBy = groupBy;
        }

        #endregion Methods
    }
}