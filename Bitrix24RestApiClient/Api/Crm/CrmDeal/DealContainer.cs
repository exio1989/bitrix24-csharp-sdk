using Bitrix24RestApiClient.Core;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Api.Crm.CrmDeal.Models;
using Bitrix24RestApiClient.Api.Crm.CrmDeal.Contact;
using Bitrix24RestApiClient.Api.Crm.CrmDeal.Userfield;
using Bitrix24RestApiClient.Api.Crm.CrmDeal.ProductRows;

namespace Bitrix24RestApiClient.Api.Crm.CrmDeal
{
    /// <summary>
    /// 
    /// </summary>
    public class DealContainer: AbstractEntities<Deal>
    {
        public DealContainer(IBitrix24Client client)
            :base(client, EntryPointPrefix.Deal)
        {
            UserFields = new DealsUserFields(client);
            Contacts = new DealContacts(client);
            ProductRows = new DealProductRows(client);
        }
        public DealContacts Contacts { get; private set; }
        public DealsUserFields UserFields { get; private set; }
        public DealProductRows ProductRows { get; private set; }
    }
}
