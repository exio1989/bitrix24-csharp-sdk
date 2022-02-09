using Newtonsoft.Json;

namespace Bitrix24RestApiClient.Core.Models
{
    public class AbstractEntity
    {
        /// <summary>
        /// Идентификатор сделки			
        /// Тип: integer	
        /// Только для чтения
        /// </summary>
        [JsonProperty(AbstractEntityFields.Id)]
        public int? Id { get; set; }
    }
}
