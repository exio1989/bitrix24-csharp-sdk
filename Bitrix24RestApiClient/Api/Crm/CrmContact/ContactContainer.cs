using Bitrix24RestApiClient.Core;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Api.Crm.CrmContact.Models;

namespace Bitrix24RestApiClient.Api.Crm.CrmContact
{
    public class ContactContainer:AbstractEntities<Contact>
    {
        public ContactContainer(IBitrix24Client client)
            : base(client, EntryPointPrefix.Contact)
        {
        }
    }
}
