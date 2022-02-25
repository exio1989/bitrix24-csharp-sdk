using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.src.Core;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;

namespace Bitrix24ApiClient.src
{
    public class SmartProcessContainer : AbstractEntities<SmartProcessItem>
    {
        public SmartProcessContainer(IBitrix24Client client, int entityId)
            :base(client, EntryPointPrefix.Item, entityId)
        {
        }
    }
}
