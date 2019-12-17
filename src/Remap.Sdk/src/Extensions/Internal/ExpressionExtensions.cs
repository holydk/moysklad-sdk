using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace Confetti.MoySklad.Remap.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="Expression"/>.
    /// </summary>
    internal static class ExpressionExtensions
    {
        public static string GetMemberName<T, TProperty>(this Expression<Func<T, TProperty>> parameter)
        {
            if (!(parameter.Body is MemberExpression memberExpression))
                throw new ArgumentException($"Expression '{parameter}' should refers to the field or property.");

            if (!(memberExpression.Member is MemberInfo memberInfo))
                throw new ArgumentException($"Expression '{parameter}' should refers to the field or property.");

            var memberName = memberInfo.Name;
            var member = typeof(T).GetMember(memberName, BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.MemberType == MemberTypes.Field || x.MemberType == MemberTypes.Property)
                .SingleOrDefault();

            var attr = member.GetCustomAttribute<JsonPropertyAttribute>(true);

            return attr?.PropertyName ?? memberName;
        }

        public static string GetFullMemberName<T, TProperty>(this Expression<Func<T, TProperty>> parameter)
        {
            if (!(parameter.Body is MemberExpression memberExpression))
                throw new ArgumentException($"Expression '{parameter}' should refers to the field or property.");

            var reversedMembers = new List<MemberInfo>();
            while (memberExpression != null)
            {
                if (memberExpression.NodeType != ExpressionType.MemberAccess)
                    throw new InvalidOperationException($"Expression '{parameter}' should refers to the field or property.");

                reversedMembers.Add(memberExpression.Member);
                memberExpression = memberExpression.Expression as MemberExpression;
            }

            var expanderBuilder = new StringBuilder(reversedMembers.Count * 4);
            for (int i = reversedMembers.Count - 1; i >= 0 ; i--)
            {
                if (expanderBuilder.Length > 1)
                    expanderBuilder.Append(".");

                var member = reversedMembers[i];
                var attr = member.GetCustomAttribute<JsonPropertyAttribute>(true);

                expanderBuilder.Append(attr?.PropertyName ?? member.Name);
            }

            return expanderBuilder.ToString();
        }

        public static int GetNestingLevel<T, TProperty>(this Expression<Func<T, TProperty>> parameter)
        {
            if (!(parameter.Body is MemberExpression memberExpression))
                throw new ArgumentException($"Expression '{parameter}' should refers to the field or property.");

            var nestingLevel = 0;
            while (memberExpression != null)
            {
                if (memberExpression.NodeType != ExpressionType.MemberAccess)
                    throw new InvalidOperationException($"Expression '{parameter}' should refers to the field or property.");

                memberExpression = memberExpression.Expression as MemberExpression;
                nestingLevel++;
            }

            return nestingLevel;
        }
    }
}