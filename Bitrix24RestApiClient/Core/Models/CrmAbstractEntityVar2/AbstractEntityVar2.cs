using Newtonsoft.Json;

namespace Bitrix24RestApiClient.Core.Models.CrmAbstractEntity
{
    public class AbstractEntityVar2
    {
        /// <summary>
        /// Идентификатор сделки			
        /// Тип: integer	
        /// Только для чтения
        /// </summary>
        [JsonProperty(AbstractEntityVar2Fields.Id)]
        public int? Id { get; set; }
    }
}
