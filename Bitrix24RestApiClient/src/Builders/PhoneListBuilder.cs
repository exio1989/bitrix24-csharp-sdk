using Bitrix24ApiClient.src.Models.Crm.Core;
using System.Collections.Generic;

namespace Bitrix24ApiClient.src.Builders
{
    public class PhoneListBuilder
    {
        private List<CrmMultiField> fields = new List<CrmMultiField>();

        public PhoneListBuilder SetField(string phone, string type)
        {
            fields.Add(new Phone(phone, type));
            return this;
        }

        public List<CrmMultiField> Build()
        {
            return fields;
        }
    }
}
