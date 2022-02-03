using Bitrix24ApiClient.src.Models.Crm.Core;
using System.Collections.Generic;

namespace Bitrix24ApiClient.src.Builders
{
    public class PhoneListBuilder: IPhoneListBuilder
    {
        private List<CrmMultiField> fields = new List<CrmMultiField>();

        public IPhoneListBuilder SetField(string phone, string type = EmailType.Рабочий)
        {
            fields.Add(new CrmMultiFieldPhone(phone, type));
            return this;
        }

        public List<CrmMultiField> Build()
        {
            return fields;
        }
    }
}
