
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;

namespace Bitrix24ApiClient.src
{
    public class Timeline
    {
        public TimelineComments Comments { get; private set; }
        public Timeline(IBitrix24Client client)
        {
            Comments = new TimelineComments(client);
        }
    }
}
