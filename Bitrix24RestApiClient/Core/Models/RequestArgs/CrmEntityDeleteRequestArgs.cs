using Newtonsoft.Json;

namespace Bitrix24ApiClient.src.Models
{
    public class CrmEntityDeleteRequestArgs {
        [JsonProperty("entityTypeId")]
        public int? EntityTypeId { get; set; }

        // Идентификатор удаляемой сущности
        [JsonProperty("ID")]
        public int Id { get; set; }
    }
}
