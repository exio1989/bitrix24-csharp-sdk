using Bitrix24ApiClient.src.Builders;
using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.Core.BatchStrategies;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;
using System;
using System.Threading.Tasks;

namespace Bitrix24ApiClient.src
{
    public class InvoiceStageHistories
    {
        private string entityTypePrefix = "crm.stagehistory";
        private IBitrix24Client client;

        public InvoiceStageHistories(IBitrix24Client client)
        {
            this.client = client;
            this.BatchOperations = new BatchOperations(client, entityTypePrefix);
        }

        public BatchOperations BatchOperations { get; private set; }

        public async Task<ListItemsResponse<InvoiceStageHistory>> List()
        {
            var builder = new ListRequestBuilder<InvoiceStageHistory>();
            builder.SetEntityTypeId(EntityTypeIdEnum.Invoice);
            return await client.SendPostRequest<CrmEntityListRequestArgs, ListItemsResponse<InvoiceStageHistory>>(entityTypePrefix, EntityMethod.List, builder.BuildArgs());
        }

        public async Task<ListItemsResponse<InvoiceStageHistory>> List(Action<IStageHistoriesListRequestBuilder<InvoiceStageHistory>> builderFunc)
        {
            var builder = new ListRequestBuilder<InvoiceStageHistory>();
            builder.SetEntityTypeId(EntityTypeIdEnum.Invoice);
            builderFunc(builder);
            return await client.SendPostRequest<CrmEntityListRequestArgs, ListItemsResponse<InvoiceStageHistory>>(entityTypePrefix, EntityMethod.List, builder.BuildArgs());
        }
    }
}
