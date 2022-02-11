using Bitrix24RestApiClient.Models.Core.Response.FieldsResponse;
using Newtonsoft.Json;

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
