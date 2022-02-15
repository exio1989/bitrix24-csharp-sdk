using Newtonsoft.Json;

namespace Bitrix24ApiClient.src.Models
{
    public class DealStageHistory : StageHistory
    {
        /// <summary>
        /// Идентификатор направления(воронки)
        /// Тип: string
        /// </summary>
        [JsonProperty(DealStageHistoryFields.CategoryId)]
        public string? CategoryId { get; set; }

        /// <summary>
        /// Семантика статуса(стадии)
        /// Тип: string
        /// </summary>
        [JsonProperty(DealStageHistoryFields.StageSemanticId)]
        public string? StageSemanticId { get; set; }

        /// <summary>
        /// Идентификатор стадии
        /// Тип: string
        /// </summary>
        [JsonProperty(DealStageHistoryFields.StageId)]
        public string? StageId { get; set; }
    }
}
