using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bitrix24ApiClient.src.Models
{
    public class CrmEntityUpdateArgs
    {
        [JsonProperty("entityTypeId")]
        public int? EntityTypeId { get; set; }

        [JsonProperty("ID")]
        public int Id { get; set; }

        [JsonProperty("fields")]
        public Dictionary<string, object> Fields { get; set; }
    }
}
