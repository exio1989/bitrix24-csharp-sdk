using System;

namespace Bitrix24RestApiClient.Models.Core.Attributes
{
    public class CrmYesNoFieldTypeAttribute : Attribute
    {
        public CrmYesNoFieldTypeAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }

        public string PropertyName { get; private set; }
    }
}
