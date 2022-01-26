namespace Bitrix24ApiClient.src
{
    public class Bitrix24
    {
        private Bitrix24Client client;

        public Bitrix24(string webhookUrl)
        {
            client = new Bitrix24Client(webhookUrl);
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
