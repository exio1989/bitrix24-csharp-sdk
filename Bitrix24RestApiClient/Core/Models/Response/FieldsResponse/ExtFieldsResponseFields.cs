using Newtonsoft.Json;
using System.Collections.Generic;
using Bitrix24RestApiClient.Core.Models.Response.FieldsResponse;

namespace Bitrix24RestApiClient.Core.Models.Response.FieldsResponse
{
    public class ExtFieldsResponseFields
    {
        [JsonProperty("fields")]
        public Dictionary<string, FieldInfo> Result { get; set; } = new Dictionary<string, FieldInfo>();
    }
}
