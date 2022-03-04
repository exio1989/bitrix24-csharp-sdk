using Newtonsoft.Json;

namespace Bitrix24RestApiClient.Core.Models.Response.AddItemResponse
{
    public class UpdateItemResponseItem<TEntity>
    {
        [JsonProperty("item")]
        public TEntity Item { get; set; }
    }
}
