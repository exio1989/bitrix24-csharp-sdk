#nullable enable
using Newtonsoft.Json;
using Bitrix24RestApiClient.Api.Crm.CrmStageHistory.Models.StageHistory;

namespace Bitrix24RestApiClient.Api.Crm.CrmStageHistory.Lead.Models
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
