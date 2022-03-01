using Newtonsoft.Json;
using Bitrix24RestApiClient.Core.Models.Response.BatchResponse;
using Bitrix24RestApiClient.Core.Models.Response.Common;

namespace Bitrix24RestApiClient.Core.Models.Response.BatchResponse
{
    public class BatchResponse<TCmdResultItem>
    {
        [JsonProperty("result")]
        public BatchResponseResult<TCmdResultItem> Result { get; set; }

        [JsonProperty("time")]
        public Time Time { get; set; }
    }
}
