using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.src.Core;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;

namespace Bitrix24ApiClient.src
{
    /// <summary>
    /// 
    /// </summary>
    public class Items
    {
        private IBitrix24Client client;

        public Items(IBitrix24Client client)
        {
            this.client = client;
        }
        public SmartProcessContainer ByEntityId(int entityId)
        {
            return new SmartProcessContainer(client, entityId);
        }
    }
}
