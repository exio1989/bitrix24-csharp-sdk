using Bitrix24ApiClient.Api.User;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;

namespace Bitrix24ApiClient.src
{
    public class Bitrix24
    {
        public Bitrix24(IBitrix24Client client)
        {
            Users = new Users(client);
            Crm = new Crm(client);
        }

        public Users Users { get; private set; }
        public Crm Crm { get; private set; }
    }
}
