using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.Api.Crm.Invoices.OldInvoices.Models;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bitrix24ApiClient.src
{
    public class DealProductRows
    {
        private const string entityTypePrefix = "crm.deal.productrows";
        private IBitrix24Client client;

        public DealProductRows(IBitrix24Client client)
        {
            this.client = client;
        }

        public async Task<ListResponse<ProductRow>> Get(int dealId)
        {
            return await client.SendPostRequest<object, ListResponse<ProductRow>>(entityTypePrefix, EntityMethod.Get, new
            {
                id = dealId
            });
        }

        public async Task<UpdateResponse> Set(int dealId, List<ProductRow> productRows)
        {
            return await client.SendPostRequest<object, UpdateResponse>(entityTypePrefix, EntityMethod.Set, new
            {
                id = dealId,
                rows = productRows
            });
        }
    }
}
