using System;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Models.Enums;

namespace Bitrix24RestApiClient.Core.BatchStrategies
{
    public class BatchOperationsForListResponse
    {
        public BatchOperationsForListResponse(IBitrix24Client client, EntryPointPrefix entityTypePrefix)
        {
            ListGetStrategy = new ListGetStrategyForListResponse(client, entityTypePrefix);
            ListStrategy = new ListStrategy(client, entityTypePrefix);
        }

        public ListGetStrategyForListResponse ListGetStrategy { get; private set; }
        public ListStrategy ListStrategy { get; private set; }
    }
}
