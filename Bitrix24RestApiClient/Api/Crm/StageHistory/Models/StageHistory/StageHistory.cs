using Bitrix24RestApiClient.Core.Models;
using Newtonsoft.Json;
using System;

namespace Bitrix24ApiClient.src.Models
{
    public class StageHistory : AbstractEntity
    {
        /// <summary>
        /// Тип записи.Может принимать значения: 1 - создание сущности, 2 - перевод на промежуточную стадию, 3 - перевод на финальную стадию
        /// Тип: int
        /// </summary>
        [JsonProperty(StageHistoryFields.TypeId)]
        public int? TypeId { get; set; }

        /// <summary>
        /// Идентификатор сущности, в которой изменилась стадия
        /// Тип: int
        /// </summary>
        [JsonProperty(StageHistoryFields.OwnerId)]
        public int? OwnerId { get; set; }

        /// <summary>
        /// Дата и время попадания на стадию
        /// Тип: datetime
        /// </summary>
        [JsonProperty(StageHistoryFields.CreatedTime)]
        public DateTimeOffset? CreatedTime { get; set; }
    }
}
