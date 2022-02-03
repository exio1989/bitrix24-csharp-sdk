using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.src.Core;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;

namespace Bitrix24ApiClient.src
{
    public class Deals: AbstractEntity<Deal>
    {
        public Deals(IBitrix24Client client)
            :base(client, EntityTypePrefix.Deal)
        {
            UserFields = new DealsUserFields(client);
            Contacts = new DealContacts(client);
        }
        public DealContacts Contacts { get; private set; }
        public DealsUserFields UserFields { get; private set; }
    }
}
