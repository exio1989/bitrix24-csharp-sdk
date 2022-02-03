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
        private const string entityTypePrefix = EntityTypePrefix.DealContactItems;
        private IBitrix24Client client;

        public DealContactItems(IBitrix24Client client)
        {
            this.client = client;
        }

        public async Task<ListResponse<DealContactItem>> Get(int id)
        {
            return await client.Get<ListResponse<DealContactItem>>(entityTypePrefix, new CrmEntityGetRequestArgs
            {
                Id = id 
            });
        }

        public async Task<UpdateResponse> Set(int id, List<DealContactItem> items)
        {
            return await client.Set<DealContactItem>(entityTypePrefix, new CrmEntitySetArgs<DealContactItem>
            {
                Id = id,
                Items = items
            });
        }

        public async Task<DeleteResponse> Delete(int id)
        {
            return await client.Delete(entityTypePrefix, new CrmEntityDeleteRequestArgs
            {
                Id = id
            });
        }
    }
}
