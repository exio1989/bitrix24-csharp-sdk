using Newtonsoft.Json;
using System.Collections.Generic;
using Bitrix24RestApiClient.Core.Models.Response.Common;
using Bitrix24RestApiClient.Core.Models.Response.FieldsResponse;

namespace Bitrix24RestApiClient.Core.Models.Response.FieldsResponse
{
    public class FieldsResponse
    {
        [JsonProperty("result")]
        public Dictionary<string, FieldInfo> Result { get; set; } = new Dictionary<string, FieldInfo>();

        [JsonProperty("time")]
        public Time Time { get; set; }
    }
}
