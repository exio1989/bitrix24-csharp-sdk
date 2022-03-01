using Newtonsoft.Json;
using Bitrix24RestApiClient.Core.Models.CrmAbstractEntity;
using Bitrix24RestApiClient.Api.Crm.CrmStageHistory.Models.StageHistory;

namespace Bitrix24RestApiClient.Api.Crm.CrmStageHistory.Deal.Models
{
    public class DealStageHistory : StageHistory
    {
        /// <summary>
        /// Идентификатор			
        /// Тип: integer	
        /// Только для чтения
        /// </summary>
        [JsonProperty(AbstractEntityFields.Id)]
        public int? Id { get; set; }

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
