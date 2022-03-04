using Newtonsoft.Json;
using Bitrix24RestApiClient.Core.Models.Response.Common;

namespace Bitrix24RestApiClient.Core.Models.Response.AddItemResponse
{
    public class UpdateItemResponse<TEntity>
    {
        [JsonProperty("result")]
        public UpdateItemResponseItem<TEntity> Result { get; set; }

        [JsonProperty("time")]
        public Time Time { get; set; }
    }
}
