using System;
using System.Threading.Tasks;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Builders;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Core.Models.Response;
using Bitrix24RestApiClient.Core.BatchStrategies;
using Bitrix24RestApiClient.Core.Builders.Interfaces;
using Bitrix24RestApiClient.Api.Crm.CrmDeal.Contact.Items;
using Bitrix24RestApiClient.Api.Crm.CrmDeal.Contact.Models;
using Bitrix24RestApiClient.Core.Models.Response.FieldsResponse;

namespace Bitrix24RestApiClient.Api.Crm.CrmDeal.Contact
{
    public class CompanyContacts
    {
        private EntryPointPrefix entityTypePrefix = EntryPointPrefix.CompanyContact;
        private IBitrix24Client client;
        private ByIdsStrategy byIdsStrategy;

        public CompanyContacts(IBitrix24Client client)
        {
            this.client = client;
            this.Items = new CompanyContactItems(client); 
            byIdsStrategy = new ByIdsStrategy(client); 
        }
        public CompanyContactItems Items { get; private set; }

        public async Task<FieldsResponse> Fields()
        {
            return await client.SendPostRequest<object, FieldsResponse>(entityTypePrefix, EntityMethod.Fields, new { });
        }

        public async Task<DeleteResponse> Delete(int dealId, int contactId)
        {
            var builder = new UpdateRequestBuilder<CompanyContact>();
            builder.SetId(dealId);
            builder.SetField(x => x.ContactId, contactId);
            return await client.SendPostRequest<object, DeleteResponse>(entityTypePrefix, EntityMethod.Delete, builder.BuildArgs(entityTypePrefix));
        } 

        public async Task<UpdateResponse> Add(int dealId, Action<IUpdateRequestBuilder<CompanyContact>> builderFunc)
        {
            var builder = new UpdateRequestBuilder<CompanyContact>();
            builder.SetId(dealId);
            builderFunc(builder);
            return await client.SendPostRequest<object, UpdateResponse>(entityTypePrefix, EntityMethod.Add, builder.BuildArgs(entityTypePrefix));
        }
    }
}
