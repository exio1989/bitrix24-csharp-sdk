using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bitrix24RestApiClient.Core.Models.RequestArgs
{
    public class CrmEntitySetArgs<TEntity>
    {
        [JsonProperty("ID")]
        public int Id { get; set; }

        [JsonProperty("items")]
        public List<TEntity> Items { get; set; }
    }
}
