using Bitrix24RestApiClient.src.Models.Crm.Core.Client;

namespace Bitrix24RestApiClient.Core.BatchStrategies
{
    public class BatchOperations
    {
        public BatchOperations(IBitrix24Client client, string entityTypePrefix)
        {
            ListGetStrategy = new ListGetStrategy(client, entityTypePrefix);
        }

        public ListGetStrategy ListGetStrategy { get; private set; }
    }
}
