using Newtonsoft.Json;

namespace Bitrix24ApiClient.src.Models
{
    public class BatchResponseResultError
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
    }
}
