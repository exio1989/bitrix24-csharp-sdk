using Bitrix24ApiClient.src.Builders;
using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.Core.BatchStrategies;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;
using System;
using System.Threading.Tasks;

namespace Bitrix24ApiClient.src
{
    public class LeadStageHistories
    {
        private string entityTypePrefix = "crm.stagehistory";
        private IBitrix24Client client;

        public LeadStageHistories(IBitrix24Client client)
        {
            this.client = client;
            this.BatchOperations = new BatchOperations(client, entityTypePrefix);
        }

        public BatchOperations BatchOperations { get; private set; }

        public async Task<ListItemsResponse<LeadStageHistory>> List()
        {
            var builder = new ListRequestBuilder<LeadStageHistory>();
            builder.SetEntityTypeId(EntityTypeIdEnum.Lead);
            return await client.SendPostRequest<CrmEntityListRequestArgs, ListItemsResponse<LeadStageHistory>>(entityTypePrefix, EntityMethod.List, builder.BuildArgs());
        }

        public async Task<ListItemsResponse<LeadStageHistory>> List(Action<IStageHistoriesListRequestBuilder<LeadStageHistory>> builderFunc)
        {
            var builder = new ListRequestBuilder<LeadStageHistory>();
            builder.SetEntityTypeId(EntityTypeIdEnum.Lead);
            builderFunc(builder);
            return await client.SendPostRequest<CrmEntityListRequestArgs, ListItemsResponse<LeadStageHistory>>(entityTypePrefix, EntityMethod.List, builder.BuildArgs());
        }
    }
}
