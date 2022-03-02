using System.Threading.Tasks;
using System.Collections.Generic;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Core.BatchStrategies;
using Bitrix24RestApiClient.Core.Models.Response;
using Bitrix24RestApiClient.Core.Models.Response.BatchResponse;
using Bitrix24RestApiClient.Api.Crm.CrmDeal.ProductRows.Models;
using Bitrix24RestApiClient.Api.Crm.Invoices.OldInvoices.Models;

namespace Bitrix24RestApiClient.Api.Crm.CrmDeal.ProductRows
{
    public class DealProductRows
    {
        private EntryPointPrefix entityPointPrefix = EntryPointPrefix.DealProductRows;
        private IBitrix24Client client;
        private ByIdsStrategy byIdsStrategy;

        public DealProductRows(IBitrix24Client client)
        {
            this.client = client;
            byIdsStrategy = new ByIdsStrategy(client);
        }

        public IAsyncEnumerable<ByIdBatchResponseItem<List<DealProductRow>>> GetByDealIds(List<int> dealIds)
        {
            return byIdsStrategy.Get<DealProductRow>(x=>x.Id, EntryPointPrefix.DealProductRows, dealIds);
        } 

        public async Task<ListResponse<DealProductRow>> Get(int dealId)
        {
            return await client.SendPostRequest<object, ListResponse<DealProductRow>>(entityPointPrefix, EntityMethod.Get, new
            {
                id = dealId
            });
        }

        public async Task<UpdateResponse> Set(int dealId, List<DealProductRow> productRows)
        {
            return await client.SendPostRequest<object, UpdateResponse>(entityPointPrefix, EntityMethod.Set, new
            {
                id = dealId,
                rows = productRows
            });
        }
    }
}
