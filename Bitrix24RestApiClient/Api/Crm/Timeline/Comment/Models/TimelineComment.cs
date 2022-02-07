using Newtonsoft.Json;

namespace Bitrix24ApiClient.src.Models.Crm.Timeline.Comment
{
    //TODO
    public class TimelineComment
    {
        [JsonProperty(TimelineCommentFields.Id)]
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
