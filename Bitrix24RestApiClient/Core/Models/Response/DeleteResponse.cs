using Newtonsoft.Json;
using Bitrix24RestApiClient.Core.Models.Response.Common;

namespace Bitrix24RestApiClient.Core.Models.Response
{
    public class DeleteResponse
    {
        [JsonProperty("result")]
        public bool Result { get; set; }

        [JsonProperty("time")]
        public Time Time { get; set; }
    }
}
