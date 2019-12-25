using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Confetti.MoySklad.Remap.Client;

namespace Confetti.MoySklad.Remap.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="Expression"/>.
    /// </summary>
    internal static class ExpressionExtensions
    {
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

        public static FilterAttribute GetFilter(this LambdaExpression parameter)
        {
            if (!(parameter.Body is MemberExpression memberExpression))
                throw new ArgumentException($"Expression '{parameter}' should refers to the field or property.");

            if (!(memberExpression.Member is MemberInfo memberInfo))
                throw new ArgumentException($"Expression '{parameter}' should refers to the field or property.");

            return memberInfo.GetCustomAttribute<FilterAttribute>(true);
        }

        public static string GetFilterName(this LambdaExpression parameter)
        {
            if (!(parameter.Body is MemberExpression memberExpression))
                throw new ArgumentException($"Expression '{parameter}' should refers to the field or property.");

            var members = new List<MemberInfo>();
            while (memberExpression != null)
            {
                if (memberExpression.NodeType != ExpressionType.MemberAccess)
                    throw new InvalidOperationException($"Expression '{parameter}' should refers to the field or property.");

                members.Add(memberExpression.Member);
                memberExpression = memberExpression.Expression as MemberExpression;
            }

            members.Reverse();

            var expanderBuilder = new StringBuilder(members.Count * 4);
            for (int i = 0; i < members.Count; i++)
            {
                var member = members[i];
                var filter = member.GetCustomAttribute<FilterAttribute>(true);
                if (filter == null)
                    throw new ApiException(400, $"Filter by member '{member.Name}' not available.");

                if (!filter.AllowNesting && members.Count - 1 > i)
                    throw new ApiException(400, $"Filter by member '{member.Name}' is invalid. Filter nesting level should be {i + 1}.");
            
                if (filter.AllowNesting && !filter.AllowFilterByRootNestingMember && members.Count - 1 == i)
                    throw new ApiException(400, $"Filter by member '{member.Name}' not available. Filter is available only for nesting member(s).");
            
                if (expanderBuilder.Length > 1)
                    expanderBuilder.Append(".");

                expanderBuilder.Append(member.GetParameterName());
            }

            return expanderBuilder.ToString();
        }

        public static string GetFullParameterName<T, TProperty>(this Expression<Func<T, TProperty>> parameter)
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

                expanderBuilder.Append(member.GetParameterName());
            }

            return expanderBuilder.ToString();
        }

        public static string GetParameterName(this LambdaExpression parameter)
        {
            if (!(parameter.Body is MemberExpression memberExpression))
                throw new ArgumentException($"Expression '{parameter}' should refers to the field or property.");

            if (!(memberExpression.Member is MemberInfo memberInfo))
                throw new ArgumentException($"Expression '{parameter}' should refers to the field or property.");

            return GetParameterName(memberInfo);
        }

        public static string GetParameterName(this MemberInfo memberInfo)
        {
            if (memberInfo == null)
                throw new ArgumentNullException(nameof(memberInfo));

            return memberInfo.GetCustomAttribute<ParameterAttribute>(true)?.Name ?? memberInfo.Name;
        }
    }
}