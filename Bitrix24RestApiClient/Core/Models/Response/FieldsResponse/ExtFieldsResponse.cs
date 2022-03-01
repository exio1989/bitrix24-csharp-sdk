using Newtonsoft.Json;
using Bitrix24RestApiClient.Core.Models.Response.Common;
using Bitrix24RestApiClient.Core.Models.Response.FieldsResponse;

namespace Bitrix24RestApiClient.Core.Models.Response.FieldsResponse
{
    public class ExtFieldsResponse
    {
        [JsonProperty("result")]
        public ExtFieldsResponseFields Fields { get; set; }

        [JsonProperty("time")]
        public Time Time { get; set; }
    }
}
