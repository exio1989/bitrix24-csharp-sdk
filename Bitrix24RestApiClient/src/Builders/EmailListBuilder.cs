using Bitrix24ApiClient.src.Models.Crm.Core;
using System.Collections.Generic;

namespace Bitrix24ApiClient.src.Builders
{
    public class EmailListBuilder
    {
        private List<CrmMultiField> fields = new List<CrmMultiField>();

        public EmailListBuilder SetField(string email, string type = EmailType.Рабочий)
        {
            fields.Add(new Email(email, type));
            return this;
        }

        public List<CrmMultiField> Build()
        {
            return fields;
        }
    }
}
