using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bitrix24RestApiClient.Core.Models.RequestArgs
{
    public class CrmEntityListRequestArgs
    {        
        [JsonProperty("entityTypeId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? EntityTypeId { get; set; }

        [JsonProperty("select", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<string> Select { get; set; }

        [JsonProperty("order", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Dictionary<string, string> Order { get; set; }

        [JsonProperty("filter", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Dictionary<string, object> Filter { get; set; }

        [JsonProperty("start", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? Start { get; set; }
    }
}
