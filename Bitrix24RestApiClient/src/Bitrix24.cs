using Bitrix24RestApiClient.src.Models.Crm.Core.Client;

namespace Bitrix24ApiClient.src
{
    public class Bitrix24
    {
        private IBitrix24Client client;

        public Bitrix24(IBitrix24Client client)
        {
            this.client = client;
            Users = new Users(client);
            Deals = new Deals(client);
            Companies = new Companies(client);
            Contacts = new Contacts(client);
            Timeline = new Timeline(client);
        }

        public Users Users { get; private set; }
        public Companies Companies { get; private set; }
        public Deals Deals { get; private set; }
        public Contacts Contacts { get; private set; }
        public Timeline Timeline { get; private set; }
    }
}
