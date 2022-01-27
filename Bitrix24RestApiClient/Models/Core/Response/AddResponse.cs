using Bitrix24RestApiClient.src.Models.Crm.Core.Response;
using Newtonsoft.Json;

namespace Bitrix24ApiClient.src.Models
{
    public class AddResponse
    {
        [JsonProperty("result")]
        public int Result { get; set; }

        [JsonProperty("time")]
        public Time Time { get; set; }
    }
}
