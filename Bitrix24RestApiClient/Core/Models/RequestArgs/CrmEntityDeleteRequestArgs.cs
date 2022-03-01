using Newtonsoft.Json;

namespace Bitrix24RestApiClient.Core.Models.RequestArgs
{
    public class CrmEntityDeleteRequestArgs {
        [JsonProperty("entityTypeId")]
        public int? EntityTypeId { get; set; }

        // Идентификатор удаляемой сущности
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
