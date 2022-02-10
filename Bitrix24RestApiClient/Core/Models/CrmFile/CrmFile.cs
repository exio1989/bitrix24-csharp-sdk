using Bitrix24RestApiClient.Core.Models;
using Newtonsoft.Json;

namespace Bitrix24ApiClient.src.Models
{
    public class CrmFile: AbstractEntity
    {
        [JsonProperty(CrmFileFields.ShowUrl)]
        public string ShowUrl { get; set; }

        [JsonProperty(CrmFileFields.DownloadUrl)]
        public string DownloadUrl { get; set; } 
    }
}
