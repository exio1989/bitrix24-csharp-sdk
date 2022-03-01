using Newtonsoft.Json;
using Bitrix24RestApiClient.Core.Models.Response.Common;

namespace Bitrix24RestApiClient.Core.Models.Response
{
    public class GetItemResponse<TEntity>
    {
        [JsonProperty("item")]
        public TEntity Item { get; set; }
    }
}
