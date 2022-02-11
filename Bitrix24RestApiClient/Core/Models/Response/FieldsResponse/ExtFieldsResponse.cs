using Bitrix24RestApiClient.src.Models.Crm.Core.Response;
using Newtonsoft.Json;

namespace Bitrix24ApiClient.src.Models
{
    public class ExtFieldsResponse
    {
        [JsonProperty("result")]
        public ExtFieldsResponseFields Fields { get; set; }

        [JsonProperty("time")]
        public Time Time { get; set; }
    }
}
