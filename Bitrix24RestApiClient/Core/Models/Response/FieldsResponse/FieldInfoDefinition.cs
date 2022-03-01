using Newtonsoft.Json;
using Bitrix24RestApiClient.Core.Models.Response.FieldsResponse;

namespace Bitrix24RestApiClient.Core.Models.Response.FieldsResponse
{
    public class FieldInfoDefinition
    {
        [JsonProperty("key")]
        public FieldInfo Key { get; set; }

        [JsonProperty("value")]
        public FieldInfo Value { get; set; }
    }
}
