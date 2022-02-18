using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.Api.Crm.Invoices.OldInvoices.Models;
using Bitrix24RestApiClient.Core.BatchStrategies;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bitrix24ApiClient.src
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
            return byIdsStrategy.Get<List<DealProductRow>>(EntryPointPrefix.DealProductRows, dealIds);
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
