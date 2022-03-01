using Newtonsoft.Json;

namespace Bitrix24RestApiClient.Core.Models.Response.FieldsResponse
{
    public class FieldInfoEnumerationItem
    {
        [JsonProperty("ID")]
        public int? Id { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }
    }
}
