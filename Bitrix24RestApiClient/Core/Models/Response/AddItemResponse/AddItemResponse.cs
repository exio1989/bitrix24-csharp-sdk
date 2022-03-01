using Newtonsoft.Json;
using Bitrix24RestApiClient.Core.Models.Response.AddItemResponse;
using Bitrix24RestApiClient.Core.Models.Response.Common;

namespace Bitrix24RestApiClient.Core.Models.Response.AddItemResponse
{
    public class AddItemResponse<TEntity>
    {
        [JsonProperty("result")]
        public AddItemResponseItem<TEntity> Result { get; set; }

        [JsonProperty("time")]
        public Time Time { get; set; }
    }
}
