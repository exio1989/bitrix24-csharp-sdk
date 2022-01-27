using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bitrix24ApiClient.src.Models
{
    public class CrmEntityUpdateArgs
    {
        [JsonProperty("ID")]
        public int Id { get; set; }

        [JsonProperty("fields")]
        public Dictionary<string, object> Fields { get; set; }
    }
}
