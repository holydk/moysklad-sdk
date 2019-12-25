using System;
using System.Reflection;
using Confetti.MoySklad.Remap.Client;

namespace Confetti.MoySklad.Remap.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="Enum"/>.
    /// </summary>
    internal static class EnumExtensions
    {
        public static string GetParameterName(this Enum value)
        {
            var memberInfo = value.GetType().GetMember(value.ToString())[0];
            return memberInfo.GetParameterName();
        }
    }
}