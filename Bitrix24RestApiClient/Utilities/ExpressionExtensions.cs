using Bitrix24RestApiClient.Models.Core.Enums;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Bitrix24RestApiClient.src.Utilities
{
    public static class ExpressionExtensions
    {
        public static string JsonPropertyName<TEntity>(this Expression<Func<TEntity, object>> self)
        {
            var memberInfo = ReflectionHelper.GetMemberInfo(self);

            return ReflectionHelper.GetPropertyNameFromJsonPropertyAttribute(memberInfo) 
                ?? ReflectionHelper.GetPropertyNameFromCrmYesNoFieldTypeAttribute(memberInfo)
                ?? memberInfo.Name;
        }

        public static object MapValue<TEntity>(this Expression<Func<TEntity, object>> self, object value)
        {
            var memberInfo = ReflectionHelper.GetMemberInfo(self);

            var isCrmYesNoField = memberInfo.CustomAttributes
                .Any(x => x.AttributeType.FullName == "Bitrix24RestApiClient.Models.Core.Attributes.CrmYesNoFieldTypeAttribute");
            if (isCrmYesNoField)
            {
                bool boolValue = (value as bool?) ?? throw new NullReferenceException("Для свойства, которое принимает Y или N нул недопустим");

                return boolValue
                    ? YesNoEnum.Y.ToString("F")
                    : YesNoEnum.N.ToString("F");
            }

            bool isCrmStatusSemanticIdField = memberInfo.CustomAttributes
                .Any(x => x.AttributeType.FullName == "Bitrix24RestApiClient.Models.Core.Attributes.CrmStatusSemanticIdTypeAttribute");
            if (isCrmStatusSemanticIdField)
            {
                StatusSemanticIdEnum enumValue = (value as StatusSemanticIdEnum?) ?? throw new NullReferenceException("Для свойства, которое принимает F, S или P нул недопустим");

                switch (enumValue)
                {
                    case StatusSemanticIdEnum.Failed:
                        return "F";//TODO дубль строки
                    case StatusSemanticIdEnum.Success:
                        return "S";
                    case StatusSemanticIdEnum.Processing:
                        return "P";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return value;
        }
    }
}
