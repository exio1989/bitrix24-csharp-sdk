using System.Threading.Tasks;
using System.Collections.Generic;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Core.Models.Response;
using Bitrix24RestApiClient.Core.Models.RequestArgs;
using Bitrix24RestApiClient.Api.Crm.CrmDeal.Contact.Items.Models;

namespace Bitrix24RestApiClient.Api.Crm.CrmDeal.Contact.Items
{
    public class CompanyContactItems
    {
        private EntryPointPrefix entityTypePrefix = EntryPointPrefix.CompanyContactItems;
        private IBitrix24Client client;

        public CompanyContactItems(IBitrix24Client client)
        {
            this.client = client;
        }

        public async Task<ListResponse<CompanyContactItem>> Get(int id)
        {
            return await client.SendPostRequest<CrmEntityGetRequestArgs, ListResponse<CompanyContactItem>>(entityTypePrefix, EntityMethod.Get, new CrmEntityGetRequestArgs
            {
                Id = id
            });
        }

        public async Task<UpdateResponse> Set(int id, List<CompanyContactItem> items)
        {
            return await client.SendPostRequest<CrmEntitySetArgs<CompanyContactItem>, UpdateResponse>(entityTypePrefix, EntityMethod.Set, new CrmEntitySetArgs<CompanyContactItem>
            {
                Id = id,
                Items = items
            });
        }

        public async Task<DeleteResponse> Delete(int id)
        {
            return await client.SendPostRequest<CrmEntityDeleteRequestArgs, DeleteResponse>(entityTypePrefix, EntityMethod.Delete, new CrmEntityDeleteRequestArgs
            {
                Id = id
            });
        }
    }
}
