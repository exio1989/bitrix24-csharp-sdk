using Bitrix24RestApiClient.src.Models.Crm.Core.Response;
using Newtonsoft.Json;

namespace Bitrix24ApiClient.src.Models
{
    public class UpdateResponse
    {
        [JsonProperty("result")]
        public bool Result { get; set; }

        [JsonProperty("time")]
        public Time Time { get; set; }
    }
}
