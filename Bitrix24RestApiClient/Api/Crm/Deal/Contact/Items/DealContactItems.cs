using Bitrix24ApiClient.src.Builders;
using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.Api.Crm.Deal.Contact.Models;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bitrix24ApiClient.src
{
    public class DealContactItems
    {
        private const string entityTypePrefix = EntryPointPrefix.DealContactItems;
        private IBitrix24Client client;

        public DealContactItems(IBitrix24Client client)
        {
            this.client = client;
        }

        public async Task<ListResponse<DealContactItem>> Get(int id)
        {
            return await client.SendPostRequest<CrmEntityGetRequestArgs, ListResponse<DealContactItem>>(entityTypePrefix, EntityMethod.Get, new CrmEntityGetRequestArgs
            {
                Id = id
            });
        }

        public async Task<UpdateResponse> Set(int id, List<DealContactItem> items)
        {
            return await client.SendPostRequest<CrmEntitySetArgs<DealContactItem>, UpdateResponse>(entityTypePrefix, EntityMethod.Set, new CrmEntitySetArgs<DealContactItem>
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
