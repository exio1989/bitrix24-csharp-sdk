using System;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Models.Enums;

namespace Bitrix24RestApiClient.Core.BatchStrategies
{
    public class BatchOperationsForListItemsResponse
    {
        public BatchOperationsForListItemsResponse(IBitrix24Client client, EntryPointPrefix entityTypePrefix, int? entityTypeId = null)
        {
            ListGetStrategy = new ListGetStrategyForListItemsResponse(client, entityTypePrefix, entityTypeId);
            ListStrategy = new ListStrategy(client, entityTypePrefix);
        }

        public ListGetStrategyForListItemsResponse ListGetStrategy { get; private set; }
        public ListStrategy ListStrategy { get; private set; }
    }
}
