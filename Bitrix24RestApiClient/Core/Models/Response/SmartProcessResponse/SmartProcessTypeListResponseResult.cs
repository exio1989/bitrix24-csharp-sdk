using Newtonsoft.Json;
using System.Collections.Generic;
using Bitrix24RestApiClient.Api.Crm.SmartProcessTypes.Models;
using Bitrix24RestApiClient.Core.Models.Response.ListItemsResponse;

namespace Bitrix24RestApiClient.Core.Models.Response.SmartProcessResponse
{
    public class SmartProcessTypeListResponseResult
    {
        [JsonProperty("types")]
        public List<SmartProcessType> Items { get; set; }
    }
}
