using System;
using System.Threading.Tasks;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Builders;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Core.Models.Response;
using Bitrix24RestApiClient.Core.Models.RequestArgs;
using Bitrix24RestApiClient.Core.Builders.Interfaces;
using Bitrix24RestApiClient.Api.Crm.CrmDeal.Contact.Items;
using Bitrix24RestApiClient.Api.Crm.CrmDeal.Contact.Models;
using Bitrix24RestApiClient.Core.Models.Response.FieldsResponse;
using System.Collections.Generic;
using Bitrix24RestApiClient.Core.Models.Response.BatchResponse;
using Bitrix24RestApiClient.Core.BatchStrategies;
using Bitrix24RestApiClient.Api.Crm.CrmDeal.Contact.Items.Models;

namespace Bitrix24RestApiClient.Api.Crm.CrmDeal.Contact
{
    public class DealContacts
    {
        private EntryPointPrefix entityTypePrefix = EntryPointPrefix.DealContact;
        private IBitrix24Client client;
        private ByIdsStrategy byIdsStrategy;

        public DealContacts(IBitrix24Client client)
        {
            this.client = client;
            this.Items = new DealContactItems(client);
            byIdsStrategy = new ByIdsStrategy(client);
        }
        public DealContactItems Items { get; private set; }

        public IAsyncEnumerable<ByIdBatchResponseItem<List<DealContactItem>>> GetByDealIds(List<int> dealIds)
        {
            return byIdsStrategy.Get<DealContactItem>(x => x.Id, EntryPointPrefix.DealContactItems, dealIds);
        }

        public async Task<FieldsResponse> Fields()
        {
            return await client.SendPostRequest<object, FieldsResponse>(entityTypePrefix, EntityMethod.Fields, new { });
        }

        public async Task<DeleteResponse> Delete(int dealId, int contactId)
        {
            var builder = new UpdateRequestBuilder<DealContact>();
            builder.SetId(dealId);
            builder.SetField(x => x.ContactId, contactId);
            return await client.SendPostRequest<object, DeleteResponse>(entityTypePrefix, EntityMethod.Delete, builder.BuildArgs(entityTypePrefix));
        } 

        public async Task<UpdateResponse> Add(int dealId, Action<IUpdateRequestBuilder<DealContact>> builderFunc)
        {
            var builder = new UpdateRequestBuilder<DealContact>();
            builder.SetId(dealId);
            builderFunc(builder);
            return await client.SendPostRequest<object, UpdateResponse>(entityTypePrefix, EntityMethod.Add, builder.BuildArgs(entityTypePrefix));
        }
    }
}
