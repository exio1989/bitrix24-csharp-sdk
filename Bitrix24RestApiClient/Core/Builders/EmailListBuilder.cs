using System.Collections.Generic;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Core.Builders.Interfaces;
using Bitrix24RestApiClient.Core.Models.CrmMultiField;
using Bitrix24RestApiClient.Core.Models.CrmMultiField.implementations;

namespace Bitrix24RestApiClient.Core.Builders
{
    public class EmailListBuilder: IEmailListBuilder
    {
        private List<CrmMultiField> fields = new List<CrmMultiField>();

        public IEmailListBuilder SetField(string email, string type = EmailType.Рабочий)
        {
            fields.Add(new CrmMultiFieldEmail(email, type));
            return this;
        }

        public List<CrmMultiField> Build()
        {
            return fields;
        }
    }
}
