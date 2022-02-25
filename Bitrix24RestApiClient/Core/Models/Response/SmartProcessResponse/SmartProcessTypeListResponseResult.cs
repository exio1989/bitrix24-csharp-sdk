using Bitrix24ApiClient.src.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bitrix24RestApiClient.Core.Models.Response.ListItemsResponse
{
    public class SmartProcessTypeListResponseResult
    {
        [JsonProperty("types")]
        public List<SmartProcessType> Items { get; set; }
    }
}
