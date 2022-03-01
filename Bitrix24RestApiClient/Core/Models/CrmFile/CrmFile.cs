using Newtonsoft.Json;
using Bitrix24RestApiClient.Core.Models.CrmAbstractEntity;

namespace Bitrix24RestApiClient.Core.Models.CrmFile
{
    public class CrmFile: IAbstractEntity
    {
        /// <summary>
        /// Идентификатор			
        /// Тип: integer	
        /// Только для чтения
        /// </summary>
        [JsonProperty(AbstractEntityFields.Id)]
        public int? Id { get; set; }

        [JsonProperty(CrmFileFields.ShowUrl)]
        public string ShowUrl { get; set; }

        [JsonProperty(CrmFileFields.DownloadUrl)]
        public string DownloadUrl { get; set; } 
    }
}
