using System;
using System.Threading.Tasks;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Builders;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Core.BatchStrategies;
using Bitrix24RestApiClient.Core.Models.RequestArgs;
using Bitrix24RestApiClient.Core.Builders.Interfaces;
using Bitrix24RestApiClient.Api.Crm.CrmStageHistory.Deal.Models;
using Bitrix24RestApiClient.Core.Models.Response.ListItemsResponse;

namespace Bitrix24RestApiClient.Api.Crm.CrmStageHistory.Deal
{
    public class DealStageHistories
    {
        private EntryPointPrefix entityTypePrefix = EntryPointPrefix.StageHistory;
        private IBitrix24Client client;

        public DealStageHistories(IBitrix24Client client)
        {
            this.client = client;
            this.BatchOperations = new BatchOperationsForListResponse(client, entityTypePrefix);
        }

        public BatchOperationsForListResponse BatchOperations { get; private set; }

        public async Task<ListItemsResponse<DealStageHistory>> List()
        {
            var builder = new ListRequestBuilder<DealStageHistory>();
            builder.SetEntityTypeId(EntityTypeIdEnum.Deal);
            return await client.SendPostRequest<CrmEntityListRequestArgs, ListItemsResponse<DealStageHistory>>(entityTypePrefix, EntityMethod.List, builder.BuildArgs());
        }

        public async Task<ListItemsResponse<DealStageHistory>> List(Action<IStageHistoriesListRequestBuilder<DealStageHistory>> builderFunc)
        {
            var builder = new ListRequestBuilder<DealStageHistory>();
            builder.SetEntityTypeId(EntityTypeIdEnum.Deal);
            builderFunc(builder);
            return await client.SendPostRequest<CrmEntityListRequestArgs, ListItemsResponse<DealStageHistory>>(entityTypePrefix, EntityMethod.List, builder.BuildArgs());
        }
    }
}
