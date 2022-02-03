using Bitrix24ApiClient.src.Builders;
using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.Api.Crm.Deal.Contact.Models;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;
using System;
using System.Threading.Tasks;

namespace Bitrix24ApiClient.src
{
    public class DealContacts
    {
        private const string entityTypePrefix = EntityTypePrefix.DealContact;
        private IBitrix24Client client;

        public DealContacts(IBitrix24Client client)
        {
            this.client = client;
            this.Items = new DealContactItems(client);
        }
        public DealContactItems Items { get; private set; }

        public async Task<FieldsResponse> Fields()
        {
            return await client.Fields(entityTypePrefix);
        }

        public async Task<DeleteResponse> Delete(int dealId, int contactId)
        {
            var builder = new UpdateRequestBuilder<DealContact>();
            builder.SetId(dealId);
            builder.SetField(x => x.ContactId, contactId);
            return await client.SendPostRequest<CrmEntityUpdateArgs, DeleteResponse>(entityTypePrefix, EntityMethodEnum.Delete, builder.BuildArgs());
        } 

        public async Task<UpdateResponse> Add(int dealId, Action<IUpdateRequestBuilder<DealContact>> builderFunc)
        {
            var builder = new UpdateRequestBuilder<DealContact>();
            builder.SetId(dealId);
            builderFunc(builder);
            return await client.SendPostRequest<CrmEntityUpdateArgs, UpdateResponse>(entityTypePrefix, EntityMethodEnum.Add, builder.BuildArgs());
        }
    }
}
