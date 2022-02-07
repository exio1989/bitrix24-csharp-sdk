using Bitrix24RestApiClient.Models.Core.Enums;
using System;

namespace Bitrix24RestApiClient.Models.Core.Attributes
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
