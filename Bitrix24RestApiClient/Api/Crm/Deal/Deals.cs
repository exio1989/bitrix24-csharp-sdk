using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.src.Core;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;

namespace Bitrix24ApiClient.src
{
    public class Deals: AbstractEntity
    {
        public Deals(IBitrix24Client client)
            :base(client, EntityTypePrefix.Deal)
        {
            UserFields = new DealsUserFields(client);
        }
        public DealsUserFields UserFields { get; private set; }
    }
}
