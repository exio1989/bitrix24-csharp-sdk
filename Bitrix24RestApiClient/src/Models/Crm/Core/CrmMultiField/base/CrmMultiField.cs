using Newtonsoft.Json;

namespace Bitrix24ApiClient.src.Models.Crm.Core
{
    public class CrmMultiField
    {
        [JsonProperty(CrmMultiFieldFields.Id)]
        public string Id { get; set; }

        [JsonProperty(CrmMultiFieldFields.ValueType)]
        public string ValueType { get; set; }

        [JsonProperty(CrmMultiFieldFields.Value)]
        public string Value { get; set; }

        [JsonProperty(CrmMultiFieldFields.TypeId)]
        public string TypeId { get; set; }
    }
}
