using Newtonsoft.Json;
using Bitrix24RestApiClient.Core.Models.Response.Common;

namespace Bitrix24RestApiClient.Core.Models.Response
{
    public class AddResponse
    {
        [JsonProperty("result")]
        public int Result { get; set; }

        [JsonProperty("time")]
        public Time Time { get; set; }
    }
}
