using Newtonsoft.Json;

namespace Bitrix24ApiClient.src.Models
{
    public class LeadStageHistory : StageHistory
    {
        /// <summary>
        /// Семантика статуса(стадии)
        /// Тип: string
        /// </summary>
        [JsonProperty(LeadStageHistoryFields.StatusSemanticId)]
        public string? StatusSemanticId { get; set; }

        /// <summary>
        /// Идентификатор статуса
        /// Тип: string
        /// </summary>
        [JsonProperty(LeadStageHistoryFields.StatusId)]
        public string? StatusId { get; set; }
    }
}
