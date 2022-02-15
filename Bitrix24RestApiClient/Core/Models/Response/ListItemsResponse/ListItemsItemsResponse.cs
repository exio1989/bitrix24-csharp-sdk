using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bitrix24RestApiClient.Core.Models.Response.ListItemsResponse
{
    public class ListItemsItemsResponse<TEntity>
    {
        [JsonProperty("items")]
        public List<TEntity> Items { get; set; }
    }
}
