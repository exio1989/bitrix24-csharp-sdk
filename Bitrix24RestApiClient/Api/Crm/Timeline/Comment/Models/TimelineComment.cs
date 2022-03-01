using Newtonsoft.Json;
using Bitrix24RestApiClient.Core.Models.CrmAbstractEntity;

namespace Bitrix24RestApiClient.Api.Crm.Timeline.Comment.Models
{
    //TODO
    public class TimelineComment: IAbstractEntity
    {
        /// <summary>
        /// Идентификатор			
        /// Тип: integer	
        /// Только для чтения
        /// </summary>
        [JsonProperty(AbstractEntityFields.Id)]
        public int? Id { get; set; }

        [JsonProperty(TimelineCommentFields.EntityType)]
        public string EntityType { get; set; }

        [JsonProperty(TimelineCommentFields.EntityId)]
        public int? EntityId { get; set; }

        [JsonProperty(TimelineCommentFields.Created)]
        public string Created { get; set; }

        [JsonProperty(TimelineCommentFields.Comment)]
        public string Comment { get; set; }

        [JsonProperty(TimelineCommentFields.AuthorId)]
        public int? AuthorId { get; set; }
    }
}
