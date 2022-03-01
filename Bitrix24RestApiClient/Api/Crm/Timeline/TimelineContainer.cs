using Bitrix24RestApiClient.Api.Crm.Timeline.Comment;
using Bitrix24RestApiClient.Core.Client;

namespace Bitrix24RestApiClient.Api.Crm.Timeline
{
    //TODO обязательные поля о них трудно узнать
    public class TimelineContainer
    {
        public TimelineContainer(IBitrix24Client client)
        {
            Comments = new TimelineComments(client);
        }

        public TimelineComments Comments { get; private set; }
    }
}
