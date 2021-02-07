using System;

namespace Confiti.MoySklad.Remap.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="Enum"/>.
    /// </summary>
    internal static class EnumExtensions
    {
        #region Methods

        public static string GetParameterName(this Enum value)
        {
            var memberInfo = value.GetType().GetMember(value.ToString())[0];
            return memberInfo.GetParameterName();
        }
            
        #endregion
    }
}