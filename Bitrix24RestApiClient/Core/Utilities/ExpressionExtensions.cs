using System;
using System.Linq;
using System.Globalization;
using System.Linq.Expressions;
using Bitrix24RestApiClient.Core.Attributes;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Api.Crm.Invoices.OldInvoices.Enums;

namespace Bitrix24RestApiClient.Core.Utilities
{
    public static class ExpressionExtensions
    {
        public static string JsonPropertyNameByExpr<TEntity>(Expression<Func<TEntity, object>> expr)
        {
            var memberInfo = ReflectionHelper.GetMemberInfo(expr);

            return ReflectionHelper.GetPropertyNameFromJsonPropertyAttribute(memberInfo)
                ?? ReflectionHelper.GetPropertyNameFromCrmFieldAttribute(memberInfo)
                ?? memberInfo.Name;
        }

        public static string JsonPropertyName<TEntity>(this Expression<Func<TEntity, object>> self)
        {
            return JsonPropertyNameByExpr(self);
        }

        public static object MapValue<TEntity>(this Expression<Func<TEntity, object>> self, object value)
        {
            var memberInfo = ReflectionHelper.GetMemberInfo(self);

            var crmField = memberInfo.CustomAttributes
                .FirstOrDefault(x => x.AttributeType.FullName == typeof(CrmFieldAttribute).FullName);

            if (crmField != null)
            {
                object fieldTypeObj = crmField.ConstructorArguments.ToArray()[1].Value;
                if (fieldTypeObj == null)
                    throw new NullReferenceException();

                CrmFieldSubTypeEnum fieldType = (CrmFieldSubTypeEnum)fieldTypeObj;
                switch (fieldType)
                {
                    case CrmFieldSubTypeEnum.DateTimeWithFormatDdMmYyyy_HhMmSs:
                        string format = "dd.MM.yyyy HH:mm:ss";

                        if (value is DateTimeOffset)
                            return ((DateTimeOffset)value).ToUniversalTime().ToString(format);

                        if (value is DateTime)
                            return ((DateTime)value).ToString(format);

                        return value;

                    case CrmFieldSubTypeEnum.Char_YesNo:
                        bool boolValue = (value as bool?) ?? throw new NullReferenceException("Для свойства, которое принимает Y или N нул недопустим");

                        return boolValue
                            ? YesNoEnum.Y.ToString("F")
                            : YesNoEnum.N.ToString("F");

                    case CrmFieldSubTypeEnum.String_StatusSemanticIdEnum:
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

                    case CrmFieldSubTypeEnum.String_InvoiceStatusEnum:
                        return (value as InvoiceStatusEnum).StatusId;

                    case CrmFieldSubTypeEnum.Int_EntityTypeIdEnum:
                        return EntityTypeIdEnum.Create((int)value);

                    case CrmFieldSubTypeEnum.Int:
                        return (int?)value;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return value;
        }
    }
}
