using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bitrix24ApiClient.src.Models
{
    public class CrmListRequestArgs
    {
        [JsonProperty("select")]
        public List<string> Select { get; set; } = new List<string>();

        [JsonProperty("order")]
        public Dictionary<string, string> Order { get; set; } = new Dictionary<string, string>();

        [JsonProperty("filter")]
        public Dictionary<string, string> Filter { get; set; } = new Dictionary<string, string>();

        [JsonProperty("start")]
        public int? Start { get; set; }

        public CrmListRequestArgs(ListRequestArgs args)
        {
            Select = args.Select;

            foreach (var filter in args.Filter)
                Filter.Add(filter.Name, filter.Value);

            foreach (var order in args.Order)
                Order.Add(order.Name, order.direction == OrderDirection.ASC ? "ASC" : "DESC");

            Start = args.Start;
        }
    }
}
