using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bitrix24RestApiClient.Core.Models.RequestArgs
{
    public class CrmEntityGetRequestArgs {
        [JsonProperty("entityTypeId")]
        public int? EntityTypeId { get; set; }

        // Идентификатор выбираемой сущности
        [JsonProperty("ID")]
        public int Id { get; set; }

        // Список полей, значения которых надо вернуть
        [JsonProperty("fields")]
        public List<string> Fields { get; set; } = new List<string>();
    }
}
