using System;
using Bitrix24RestApiClient.Core.Models.Enums;

namespace Bitrix24RestApiClient.Core.Attributes
{
    public class CrmFieldAttribute : Attribute
    {
        public CrmFieldAttribute(string propertyName, CrmFieldSubTypeEnum fieldType)
        {
            PropertyName = propertyName;
            FieldType = fieldType;
        }

        public string PropertyName { get; private set; }
        public CrmFieldSubTypeEnum FieldType { get; private set; }
    }
}
