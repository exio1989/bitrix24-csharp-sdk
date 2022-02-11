using Bitrix24RestApiClient.src.Models.Crm.Core.Response;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bitrix24ApiClient.src.Models
{
    public class UserFieldsResponse
    {
        [JsonProperty("result")]
        public Dictionary<string, string> Result { get; set; } = new Dictionary<string, string>();

        [JsonProperty("time")]
        public Time Time { get; set; }
    }
}
