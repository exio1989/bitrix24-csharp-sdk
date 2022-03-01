using Bitrix24RestApiClient.Api.Crm.Timeline.Comment.Models;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Core;

namespace Bitrix24RestApiClient.Api.Crm.Timeline.Comment
{
    public class TimelineComments:AbstractEntities<TimelineComment>
    {
        public TimelineComments(IBitrix24Client client)
            :base(client, EntryPointPrefix.TimelineComment)
        {
        }
    }
}
