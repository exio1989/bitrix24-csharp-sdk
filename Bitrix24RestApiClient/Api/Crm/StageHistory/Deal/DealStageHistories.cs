using Bitrix24ApiClient.src.Builders;
using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.Core.BatchStrategies;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;
using System;
using System.Threading.Tasks;

namespace Bitrix24ApiClient.src
{
    public class DealStageHistories
    {
        private string entityTypePrefix = "crm.stagehistory";
        private IBitrix24Client client;

        public DealStageHistories(IBitrix24Client client)
        {
            this.client = client;
            this.BatchOperations = new BatchOperations(client, entityTypePrefix);
        }

        public BatchOperations BatchOperations { get; private set; }

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
