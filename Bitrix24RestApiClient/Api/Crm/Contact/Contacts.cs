using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.src.Core;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;

namespace Bitrix24ApiClient.src
{
    public class Contacts:AbstractEntities<Contact>
    {
        public Contacts(IBitrix24Client client)
            : base(client, EntryPointPrefix.Contact)
        {
        }
    }
}
