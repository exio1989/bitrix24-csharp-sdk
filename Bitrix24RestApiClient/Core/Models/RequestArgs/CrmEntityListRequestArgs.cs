using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bitrix24ApiClient.src.Models
{
    public class CrmEntityListRequestArgs
    {        
        [JsonProperty("entityTypeId")]
        public int? EntityTypeId { get; set; }

        [JsonProperty("select")]
        public List<string> Select { get; set; } = new List<string>();

        [JsonProperty("order")]
        public Dictionary<string, string> Order { get; set; } = new Dictionary<string, string>();

        [JsonProperty("filter")]
        public Dictionary<string, object> Filter { get; set; } = new Dictionary<string, object>();

        [JsonProperty("start")]
        public int? Start { get; set; }
    }
}
