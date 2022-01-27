using Newtonsoft.Json;

namespace Bitrix24ApiClient.src.Models
{
    public class CrmEntityDeleteRequestArgs {
        // Идентификатор удаляемой сущности
        [JsonProperty("ID")]
        public int Id { get; set; }
    }
}
