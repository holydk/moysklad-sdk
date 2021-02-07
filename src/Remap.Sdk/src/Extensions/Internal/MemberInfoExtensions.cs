using System;
using System.Reflection;
using Confiti.MoySklad.Remap.Client;

namespace Confiti.MoySklad.Remap.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="MemberInfo"/>.
    /// </summary>
    internal static class MemberInfoExtensions
    {
        #region Methods

        public static string GetParameterName(this MemberInfo memberInfo)
        {
            if (memberInfo == null)
                throw new ArgumentNullException(nameof(memberInfo));

            return memberInfo.GetCustomAttribute<ParameterAttribute>(true)?.Name ?? memberInfo.Name;
        }

        public static FilterAttribute GetFilter(this MemberInfo memberInfo)
        {
            if (memberInfo == null)
                throw new ArgumentNullException(nameof(memberInfo));

            return memberInfo.GetCustomAttribute<FilterAttribute>(true);
        }

        public static bool IsAllowExpand(this MemberInfo memberInfo)
        {
            if (memberInfo == null)
                throw new ArgumentNullException(nameof(memberInfo));

            return memberInfo.IsDefined(typeof(AllowExpandAttribute), true);
        }

        public static bool IsAllowOrder(this MemberInfo memberInfo)
        {
            if (memberInfo == null)
                throw new ArgumentNullException(nameof(memberInfo));

            return memberInfo.IsDefined(typeof(AllowOrderAttribute), true);
        }
            
        #endregion
    }
}