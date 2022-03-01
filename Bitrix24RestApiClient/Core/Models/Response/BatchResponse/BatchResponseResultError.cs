using Newtonsoft.Json;

namespace Bitrix24RestApiClient.Core.Models.Response.BatchResponse
{
    public class BatchResponseResultError
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
    }
}
