using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bitrix24RestApiClient.Core.Models.RequestArgs
{
    public class CrmSearchRequestArgs
    {
        [JsonProperty("filter")]
        public Dictionary<string, object> Filter { get; set; } = new Dictionary<string, object>();

        [JsonProperty("ADMIN_MODE")]
        public bool? AdminMode { get; set; }

        public CrmSearchRequestArgs(List<Filter> filters)
        {
            foreach (var filter in filters)
                Filter.Add(filter.NameWithOperatorPrefix, filter.Value);
        }
    }
}
