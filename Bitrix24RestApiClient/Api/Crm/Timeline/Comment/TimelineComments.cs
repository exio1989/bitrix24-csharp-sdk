using Bitrix24ApiClient.src.Models;
using Bitrix24ApiClient.src.Models.Crm.Timeline.Comment;
using Bitrix24RestApiClient.src.Core;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;

namespace Bitrix24ApiClient.src
{
    public class TimelineComments:AbstractEntities<TimelineComment>
    {
        public TimelineComments(IBitrix24Client client)
            :base(client, EntryPointPrefix.TimelineComment)
        {
        }
    }
}
