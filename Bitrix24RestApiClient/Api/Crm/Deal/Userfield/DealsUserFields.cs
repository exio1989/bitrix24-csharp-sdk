using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.src.Core;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;

namespace Bitrix24ApiClient.src
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
