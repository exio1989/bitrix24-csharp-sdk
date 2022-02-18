using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;

namespace Bitrix24RestApiClient.Core.BatchStrategies
{
    public class BatchOperations
    {
        public BatchOperations(IBitrix24Client client, EntryPointPrefix entityTypePrefix)
        {
            ListGetStrategy = new ListGetStrategy(client, entityTypePrefix);
            ListStrategy = new ListStrategy(client, entityTypePrefix);
        }

        public ListGetStrategy ListGetStrategy { get; private set; }
        public ListStrategy ListStrategy { get; private set; }
    }
}
