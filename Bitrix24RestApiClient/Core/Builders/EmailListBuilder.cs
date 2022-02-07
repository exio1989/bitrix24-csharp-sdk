using Bitrix24ApiClient.src.Models.Crm.Core;
using System.Collections.Generic;

namespace Bitrix24ApiClient.src.Builders
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
