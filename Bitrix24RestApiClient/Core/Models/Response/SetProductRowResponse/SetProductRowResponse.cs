using Newtonsoft.Json;
using Bitrix24RestApiClient.Core.Models.Response.Common;

namespace Bitrix24RestApiClient.Core.Models.Response
{
    public class SetProductRowResponse
    {
        [JsonProperty("result")]
        public SetProductRowResponseResult Result { get; set; }

        [JsonProperty("time")]
        public Time Time { get; set; }
    }
}
