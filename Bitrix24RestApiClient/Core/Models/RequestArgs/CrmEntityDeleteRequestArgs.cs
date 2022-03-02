using Newtonsoft.Json;

namespace Bitrix24RestApiClient.Core.Models.RequestArgs
{
    public class CrmEntityDeleteRequestArgs {
        [JsonProperty("entityTypeId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? EntityTypeId { get; set; }

        // Идентификатор удаляемой сущности
        [JsonProperty("ID")]
        public int Id { get; set; }
    }
}
