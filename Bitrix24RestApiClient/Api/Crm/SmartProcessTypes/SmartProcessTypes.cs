using Bitrix24ApiClient.src.Builders;
using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;
using Bitrix24RestApiClient.src.Utilities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bitrix24ApiClient.src
{
    public class SmartProcessTypes
    {
        private EntryPointPrefix entityTypePrefix = EntryPointPrefix.SmartProcessType;
        private IBitrix24Client client;

        public SmartProcessTypes(IBitrix24Client client)
        {
            this.client = client;
        }

        public async Task<FieldsResponse> Fields()
        {
            return await client.SendPostRequest<object, FieldsResponse>(entityTypePrefix, EntityMethod.Fields, new { });
        }

        public async Task<SmartProcessTypeListResponse> List()
        {
            var builder = new ListRequestBuilder<SmartProcessType>();
            return await client.SendPostRequest<CrmEntityListRequestArgs, SmartProcessTypeListResponse>(entityTypePrefix, EntityMethod.List, builder.BuildArgs());
        }

        public async Task<SmartProcessTypeListResponse> List(Action<IListRequestBuilder<SmartProcessType>> builderFunc)
        {
            var builder = new ListRequestBuilder<SmartProcessType>();
            builderFunc(builder);
            return await client.SendPostRequest<CrmEntityListRequestArgs, SmartProcessTypeListResponse>(entityTypePrefix, EntityMethod.List, builder.BuildArgs());
        }

        public async Task<GetResponse<SmartProcessType>> Get(int id, params Expression<Func<SmartProcessType, object>>[] fieldsExpr)
        {
            return await client.SendPostRequest<CrmEntityGetRequestArgs, GetResponse<SmartProcessType>>(entityTypePrefix, EntityMethod.Get, new CrmEntityGetRequestArgs
            {
                Id = id,
                Fields = fieldsExpr.Select(x => x.JsonPropertyName()).ToList()
            });
        }

        public async Task<DeleteResponse> Delete(int id)
        {
            return await client.SendPostRequest<CrmEntityDeleteRequestArgs, DeleteResponse>(entityTypePrefix, EntityMethod.Delete, new CrmEntityDeleteRequestArgs
            {
                Id = id
            });
        }

        public async Task<UpdateResponse> Update(int id, Action<IUpdateRequestBuilder<SmartProcessType>> builderFunc)
        {
            var builder = new UpdateRequestBuilder<SmartProcessType>();
            builder.SetId(id);
            builderFunc(builder);
            return await client.SendPostRequest<CrmEntityUpdateArgs, UpdateResponse>(entityTypePrefix, EntityMethod.Update, builder.BuildArgs());
        }

        public async Task<AddResponse> Add()
        {
            var builder = new AddRequestBuilder<SmartProcessType>();
            return await client.SendPostRequest<CrmEntityAddArgs, AddResponse>(entityTypePrefix, EntityMethod.Add, builder.BuildArgs());
        }

        public async Task<AddResponse> Add(Action<IAddRequestBuilder<SmartProcessType>> builderFunc)
        {
            var builder = new AddRequestBuilder<SmartProcessType>();
            builderFunc(builder);
            return await client.SendPostRequest<CrmEntityAddArgs, AddResponse>(entityTypePrefix, EntityMethod.Add, builder.BuildArgs());
        }
    }
}
