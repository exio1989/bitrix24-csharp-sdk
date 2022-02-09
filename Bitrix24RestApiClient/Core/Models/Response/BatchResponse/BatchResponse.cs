using Bitrix24RestApiClient.src.Models.Crm.Core.Response;
using Newtonsoft.Json;

namespace Bitrix24ApiClient.src.Models
{
    public class BatchResponse<TCmdResultItem>
    {
        [JsonProperty("result")]
        public BatchResponseResult<TCmdResultItem> Result { get; set; }

        [JsonProperty("time")]
        public Time Time { get; set; }
    }
}
