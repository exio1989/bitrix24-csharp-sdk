using Bitrix24RestApiClient.Core.Models;
using Newtonsoft.Json;

namespace Bitrix24ApiClient.src.Models
{
    public class SmartProcess: AbstractEntity
    {
        /// <summary>
        /// Идентификатор смарт-процесса	
        /// Тип: string
        /// </summary>
        [JsonProperty(SmartProcessFields.EntityTypeId)]
        public string EntityTypeId { get; set; }
    }
}
