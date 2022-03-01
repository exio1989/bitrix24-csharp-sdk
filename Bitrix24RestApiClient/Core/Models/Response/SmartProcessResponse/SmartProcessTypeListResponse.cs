using Bitrix24RestApiClient.Core.Models.Response.ListItemsResponse;
using Newtonsoft.Json;
using Bitrix24RestApiClient.Core.Models.Response.Common;
using Bitrix24RestApiClient.Core.Models.Response.SmartProcessResponse;

namespace Bitrix24RestApiClient.Core.Models.Response.SmartProcessResponse
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
