using Newtonsoft.Json;
using Bitrix24RestApiClient.Core.Models.Response.Common;

namespace Bitrix24RestApiClient.Core.Models.Response
{
    public class DeleteItemResponse
    {
        [JsonProperty("time")]
        public Time Time { get; set; }
    }
}
