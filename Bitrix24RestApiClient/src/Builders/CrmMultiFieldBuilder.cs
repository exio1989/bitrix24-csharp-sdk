using Bitrix24ApiClient.src.Models.Crm.Core;
using System.Collections.Generic;

namespace Bitrix24ApiClient.src.Builders
{
    public class CrmMultiFieldBuilder
    {
        private List<CrmMultiField> fields = new List<CrmMultiField>();

        public CrmMultiFieldBuilder SetField(CrmMultiField field)
        {
            fields.Add(field);
            return this;
        }

        public List<CrmMultiField> Get()
        {
            return fields;
        }
    }
}
