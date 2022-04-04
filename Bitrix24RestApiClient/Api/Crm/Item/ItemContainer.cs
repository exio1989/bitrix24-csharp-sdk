using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Api.Crm.Item.CrmProductRow;
using Bitrix24RestApiClient.Api.Crm.Item.CrmSmartProcessContainer;

namespace Bitrix24RestApiClient.Api.Crm.Item
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemContainer
    {
        private IBitrix24Client client;

        public ItemContainer(IBitrix24Client client)
        {
            this.client = client;
            ProductRows = new ProductRows(client);
        }
        public ProductRows ProductRows { get; private set; }
        public SmartProcessContainer ByEntityId(int entityId)
        {
            return new SmartProcessContainer(client, entityId);
        }
    }
}
