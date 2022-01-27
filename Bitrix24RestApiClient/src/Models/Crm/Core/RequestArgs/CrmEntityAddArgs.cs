using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bitrix24ApiClient.src.Models
{
    public class CrmEntityAddArgs
    {
        [JsonProperty("fields")]
        public Dictionary<string, object> Fields { get; set; }
    }
}
