using Bitrix24RestApiClient.Core;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Api.Crm.CrmDeal.Models;

namespace Bitrix24RestApiClient.Api.Crm.CrmDeal.Userfield
{
    //TODO Не проверено
    public class DealsUserFields : AbstractEntities<Deal>
    {
        public DealsUserFields(IBitrix24Client client)
            : base(client, EntryPointPrefix.DealUserFields)
        {
        }
    }
}
