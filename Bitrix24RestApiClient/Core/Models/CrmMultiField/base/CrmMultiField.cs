using Bitrix24RestApiClient.Core.Models;
using Newtonsoft.Json;

namespace Bitrix24ApiClient.src.Models.Crm.Core
{
    public class CrmMultiField: AbstractEntity
    {
        [JsonProperty(CrmMultiFieldFields.ValueType)]
        public string ValueType { get; set; }

        [JsonProperty(CrmMultiFieldFields.Value)]
        public string Value { get; set; }

        [JsonProperty(CrmMultiFieldFields.TypeId)]
        public string TypeId { get; set; }
    }
}
