using Bitrix24RestApiClient.Models.Core.Enums;
using Newtonsoft.Json;

namespace Bitrix24ApiClient.src.Models
{
    public class Deal
    {
        [JsonProperty(DealFields.Id)]
        public int Id { get; set; }

        [JsonProperty(DealFields.Title)]
        public string Title { get; set; }

        [JsonProperty(DealFields.ResponsibleId)]
        public string ResponsibleId { get; set; }

        [JsonProperty(DealFields.CompanyId)]
        public string CompanyId { get; set; }

        [JsonProperty(DealFields.ContactId)]
        public string ContactId { get; set; }

        [JsonProperty(DealFields.Comments)]
        public string Comments { get; set; }

        [JsonProperty(DealFields.StageId)]
        public string StageId { get; set; }

        [JsonProperty(DealFields.Closed)]
        public YesNoEnum Closed { get; set; }

        /// <summary>
        /// Идентификатор направления
        /// </summary>

        [JsonProperty(DealFields.CategoryId)]
        public string CategoryId { get; set; }
    }
}
