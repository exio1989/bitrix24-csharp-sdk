using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Bitrix24RestApiClient.src.Utilities
{
    public static class ReflectionHelper
    {
        public static string GetPropertyNameFromJsonPropertyAttribute(MemberInfo memberInfo)
        {
            CustomAttributeTypedArgument? propertyNameArgument = memberInfo.CustomAttributes
                .FirstOrDefault(x => x.AttributeType.FullName == "Newtonsoft.Json.JsonPropertyAttribute")
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
    }
}
