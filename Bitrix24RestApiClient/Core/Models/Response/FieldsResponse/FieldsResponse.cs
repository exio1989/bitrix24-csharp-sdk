using Bitrix24RestApiClient.Models.Core.Response.FieldsResponse;
using Bitrix24RestApiClient.src.Models.Crm.Core.Response;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bitrix24ApiClient.src.Models
{
    public class FieldsResponse
    {
        [JsonProperty("result")]
        public Dictionary<string, FieldInfo> Result { get; set; } = new Dictionary<string, FieldInfo>();

        [JsonProperty("time")]
        public Time Time { get; set; }
    }
}
