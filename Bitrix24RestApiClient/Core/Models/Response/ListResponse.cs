using Bitrix24RestApiClient.src.Models.Crm.Core.Response;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bitrix24ApiClient.src.Models
{
    public class ListResponse<TEntity>
    {
        [JsonProperty("result")]
        public List<TEntity> Result { get; set; }

        [JsonProperty("next")]
        public int? Next { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("time")]
        public Time Time { get; set; }
    }
}
