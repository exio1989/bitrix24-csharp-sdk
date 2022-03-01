using System;
using System.Threading.Tasks;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Builders;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Core.BatchStrategies;
using Bitrix24RestApiClient.Core.Models.RequestArgs;
using Bitrix24RestApiClient.Core.Builders.Interfaces;
using Bitrix24RestApiClient.Api.Crm.CrmStageHistory.Lead.Models;
using Bitrix24RestApiClient.Core.Models.Response.ListItemsResponse;

namespace Bitrix24RestApiClient.Api.Crm.CrmStageHistory.Lead
{
    public class LeadStageHistories
    {
        private EntryPointPrefix entityTypePrefix = EntryPointPrefix.StageHistory;
        private IBitrix24Client client;

        public LeadStageHistories(IBitrix24Client client)
        {
            this.client = client;
            this.BatchOperations = new BatchOperationsForListResponse(client, entityTypePrefix);
        }

        public BatchOperationsForListResponse BatchOperations { get; private set; }

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
