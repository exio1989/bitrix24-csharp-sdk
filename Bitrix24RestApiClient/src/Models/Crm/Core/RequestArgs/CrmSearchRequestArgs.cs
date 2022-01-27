using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bitrix24ApiClient.src.Models
{
    public class CrmSearchRequestArgs
    {
        [JsonProperty("filter")]
        public Dictionary<string, string> Filter { get; set; } = new Dictionary<string, string>();

        public CrmSearchRequestArgs(List<Filter> filters)
        {
            foreach (var filter in filters)
                Filter.Add(filter.Name, filter.Value);
        }
    }
}
