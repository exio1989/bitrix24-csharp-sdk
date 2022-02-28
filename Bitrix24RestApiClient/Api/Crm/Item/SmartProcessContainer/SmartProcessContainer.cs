using Bitrix24ApiClient.src.Builders;
using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.Core.Models;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;
using Bitrix24RestApiClient.src.Utilities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bitrix24ApiClient.src
{
    public class SmartProcessContainer
    {
        private IBitrix24Client client;
        private EntryPointPrefix entityTypePrefix = EntryPointPrefix.Item;
        private int? entityTypeId;

        public SmartProcessContainer(IBitrix24Client client, int entityId)
        {
            this.client = client;
            entityTypeId = entityId;
        }

        public async Task<FieldsResponse> Fields()
        {
            return await client.SendPostRequest<object, FieldsResponse>(entityTypePrefix, EntityMethod.Fields, new { });
        }

        public async Task<ListItemsResponse<TCustomEntity>> List<TCustomEntity>() where TCustomEntity : AbstractEntity
        {
            var builder = new ListRequestBuilder<TCustomEntity>();
            builder.SetEntityTypeId(entityTypeId);
            return await client.SendPostRequest<CrmEntityListRequestArgs, ListItemsResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.List, builder.BuildArgs());
        }

        public async Task<ListItemsResponse<TCustomEntity>> List<TCustomEntity>(Action<IListRequestBuilder<TCustomEntity>> builderFunc) where TCustomEntity : AbstractEntity
        {
            var builder = new ListRequestBuilder<TCustomEntity>();
            builder.SetEntityTypeId(entityTypeId);
            builderFunc(builder);
            return await client.SendPostRequest<CrmEntityListRequestArgs, ListItemsResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.List, builder.BuildArgs());
        }

        public async Task<TCustomEntity> First<TCustomEntity>(Action<IListRequestBuilder<TCustomEntity>> builderFunc) where TCustomEntity : AbstractEntity
        {
            var builder = new ListRequestBuilder<TCustomEntity>();
            builder.SetEntityTypeId(entityTypeId);
            builderFunc(builder);
            return (await client.SendPostRequest<CrmEntityListRequestArgs, ListResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.List, builder.BuildArgs())).Result.FirstOrDefault();
        }

        public async Task<GetResponse<TCustomEntity>> Get<TCustomEntity>(int id, params Expression<Func<TCustomEntity, object>>[] fieldsExpr) where TCustomEntity : class
        {
            return await client.SendPostRequest<CrmEntityGetRequestArgs, GetResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.Get, new CrmEntityGetRequestArgs
            {
                EntityTypeId = entityTypeId,
                Id = id,
                Fields = fieldsExpr.Select(x => x.JsonPropertyName()).ToList()
            });
        }

        public async Task<DeleteResponse> Delete(int id)
        {
            return await client.SendPostRequest<CrmEntityDeleteRequestArgs, DeleteResponse>(entityTypePrefix, EntityMethod.Delete, new CrmEntityDeleteRequestArgs
            {
                EntityTypeId = entityTypeId,
                Id = id
            });
        }

        public async Task<UpdateResponse> Update<TCustomEntity>(int id, Action<IUpdateRequestBuilder<TCustomEntity>> builderFunc)
        {
            var builder = new UpdateRequestBuilder<TCustomEntity>();
            builder.SetEntityTypeId(entityTypeId);
            builder.SetId(id);
            builderFunc(builder);
            return await client.SendPostRequest<CrmEntityUpdateArgs, UpdateResponse>(entityTypePrefix, EntityMethod.Update, builder.BuildArgs());
        }

        public async Task<AddResponse> Add<TCustomEntity>()
        {
            var builder = new AddRequestBuilder<TCustomEntity>();
            builder.SetEntityTypeId(entityTypeId);
            return await client.SendPostRequest<CrmEntityAddArgs, AddResponse>(entityTypePrefix, EntityMethod.Add, builder.BuildArgs());
        }

        public async Task<AddResponse> Add<TCustomEntity>(Action<IAddRequestBuilder<TCustomEntity>> builderFunc)
        {
            var builder = new AddRequestBuilder<TCustomEntity>();
            builder.SetEntityTypeId(entityTypeId);
            builderFunc(builder);
            return await client.SendPostRequest<CrmEntityAddArgs, AddResponse>(entityTypePrefix, EntityMethod.Add, builder.BuildArgs());
        }
    }
}
