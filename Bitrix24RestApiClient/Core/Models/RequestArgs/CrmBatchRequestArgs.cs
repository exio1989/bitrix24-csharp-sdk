using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bitrix24ApiClient.src.Models
{
    public class CrmBatchRequestArgs
    {
        [JsonProperty("halt")]
        public int Halt { get; set; }

        [JsonProperty("cmd")]
        public Dictionary<string, string> Commands { get; set; } = new Dictionary<string, string>();
    }
}
