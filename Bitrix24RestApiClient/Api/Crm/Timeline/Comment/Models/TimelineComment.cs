using Newtonsoft.Json;

namespace Bitrix24ApiClient.src.Models.Crm.Timeline.Comment
{
    public class TimelineComment
    {
        [JsonProperty(TimelineCommentFields.Id)]
        public string Id { get; set; }

        [JsonProperty(TimelineCommentFields.EntityType)]
        public string EntityType { get; set; }

        [JsonProperty(TimelineCommentFields.EntityId)]
        public int EntityId { get; set; }

        [JsonProperty(TimelineCommentFields.Created)]
        public string Created { get; set; }

        [JsonProperty(TimelineCommentFields.Comment)]
        public string Comment { get; set; }

        [JsonProperty(TimelineCommentFields.AuthorId)]
        public string AuthorId { get; set; }
    }
}
