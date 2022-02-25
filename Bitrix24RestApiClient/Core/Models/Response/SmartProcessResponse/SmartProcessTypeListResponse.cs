using Bitrix24RestApiClient.Core.Models.Response.ListItemsResponse;
using Bitrix24RestApiClient.src.Models.Crm.Core.Response;
using Newtonsoft.Json;

namespace Bitrix24ApiClient.src.Models
{
    public class SmartProcessTypeListResponse
    {
        [JsonProperty("result")]
        public SmartProcessTypeListResponseResult Result { get; set; }

        [JsonProperty("next")]
        public int? Next { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("time")]
        public Time Time { get; set; }
    }
}
