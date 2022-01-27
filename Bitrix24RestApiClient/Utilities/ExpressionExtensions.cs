using System;
using System.Linq.Expressions;

namespace Bitrix24RestApiClient.src.Utilities
{
    public static class ExpressionExtensions
    {
        public static string JsonPropertyName<TEntity>(this Expression<Func<TEntity, object>> self)
        {
            var memberInfo = ReflectionHelper.GetMemberInfo(self);
            var propertyName = ReflectionHelper.GetPropertyNameFromJsonPropertyAttribute(memberInfo);
            return propertyName ?? memberInfo.Name;
        }
    }
}
