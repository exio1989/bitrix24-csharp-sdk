
namespace Bitrix24ApiClient.src
{
    public class Timeline
    {
        public TimelineComments Comments { get; private set; }
        public Timeline(Bitrix24Client client)
        {
            Comments = new TimelineComments(client);
        }
    }
}
