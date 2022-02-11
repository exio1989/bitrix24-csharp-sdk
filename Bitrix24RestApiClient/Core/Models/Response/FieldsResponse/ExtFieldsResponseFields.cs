using Bitrix24RestApiClient.Models.Core.Response.FieldsResponse;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bitrix24ApiClient.src.Models
{
    public class ExtFieldsResponseFields
    {
        [JsonProperty("fields")]
        public Dictionary<string, FieldInfo> Result { get; set; } = new Dictionary<string, FieldInfo>();
    }
}
