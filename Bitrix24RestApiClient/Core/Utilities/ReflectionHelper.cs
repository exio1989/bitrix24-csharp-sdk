using System;
using System.Linq;
using Newtonsoft.Json;
using System.Reflection;
using System.Linq.Expressions;
using Bitrix24RestApiClient.Core.Attributes;

namespace Bitrix24RestApiClient.Core.Utilities
{
    public static class ReflectionHelper
    {
        public static string GetPropertyNameFromJsonPropertyAttribute(MemberInfo memberInfo)
        {
            CustomAttributeTypedArgument? propertyNameArgument = memberInfo.CustomAttributes
                .FirstOrDefault(x => x.AttributeType.FullName == typeof(JsonPropertyAttribute).FullName)
                ?.ConstructorArguments.FirstOrDefault();

            if (propertyNameArgument == null)
                return null;

            return propertyNameArgument.Value.Value as string;
        }

        public static string GetPropertyNameFromCrmFieldAttribute(MemberInfo memberInfo)
        {
            CustomAttributeTypedArgument? propertyNameArgument = memberInfo.CustomAttributes
                .FirstOrDefault(x => x.AttributeType.FullName == typeof(CrmFieldAttribute).FullName)
                ?.ConstructorArguments.FirstOrDefault();

            if (propertyNameArgument == null)
                return null;

            return propertyNameArgument.Value.Value as string;
        }

        public static MemberInfo GetMemberInfo(LambdaExpression expression)
        {
            if (expression.Body.NodeType == ExpressionType.Convert)
            {
                var body = (UnaryExpression)expression.Body;
                return ((MemberExpression)body.Operand).Member;
            }

            if (expression.Body.NodeType == ExpressionType.MemberAccess)
                return ((MemberExpression)expression.Body).Member;

            throw new ArgumentException("Not a member access", "expression");
        }

        public static object? GetPropertyValue<TEntity>(LambdaExpression expression, TEntity obj)
        {
            MemberExpression memberExpr = null;

            if (expression.Body.NodeType == ExpressionType.Convert)
            {
                var body = (UnaryExpression)expression.Body;
                memberExpr = (MemberExpression)body.Operand;
            }

            if (expression.Body.NodeType == ExpressionType.MemberAccess)
                memberExpr = (MemberExpression)expression.Body;

            if(memberExpr != null)
                return ((PropertyInfo)memberExpr.Member).GetValue(obj);

            throw new ArgumentException("Not a member access", "expression");
        }
    }
}
