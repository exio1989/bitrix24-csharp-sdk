using Newtonsoft.Json;

namespace Bitrix24ApiClient.src.Models
{
    public class CrmEntityUpdateArgs
    {
        [JsonProperty("ID")]
        public string Id { get; set; }

        public object Fields { get; set; }
    }
}
