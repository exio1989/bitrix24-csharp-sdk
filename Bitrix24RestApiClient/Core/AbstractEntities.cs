using Bitrix24ApiClient.src.Builders;
using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.Core.BatchStrategies;
using Bitrix24RestApiClient.Core.Models;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;
using Bitrix24RestApiClient.src.Utilities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bitrix24RestApiClient.src.Core
{
    public class AbstractEntities<TEntity> where TEntity : AbstractEntity
    {
        private IBitrix24Client client;
        private EntryPointPrefix entityTypePrefix;

        public AbstractEntities(IBitrix24Client client, EntryPointPrefix entityTypePrefix)
        {
            this.client = client;
            this.entityTypePrefix = entityTypePrefix;
            this.BatchOperations = new BatchOperations(client, entityTypePrefix);
        }

        public BatchOperations BatchOperations { get; private set; }

        public async Task<FieldsResponse> Fields()
        {
            return await client.SendPostRequest<object, FieldsResponse>(entityTypePrefix, EntityMethod.Fields, new { });
        }

        public async Task<ListResponse<TEntity>> List()
        {
            var builder = new ListRequestBuilder<TEntity>();
            return await client.SendPostRequest<CrmEntityListRequestArgs, ListResponse<TEntity>>(entityTypePrefix, EntityMethod.List, builder.BuildArgs());
        }

        public async Task<ListResponse<TEntity>> List(Action<IListRequestBuilder<TEntity>> builderFunc)
        {
            var builder = new ListRequestBuilder<TEntity>();
            builderFunc(builder);
            return await client.SendPostRequest<CrmEntityListRequestArgs, ListResponse<TEntity>>(entityTypePrefix, EntityMethod.List, builder.BuildArgs());
        }

        public async Task<ListResponse<TCustomEntity>> List<TCustomEntity>() where TCustomEntity: AbstractEntity
        {
            var builder = new ListRequestBuilder<TCustomEntity>();
            return await client.SendPostRequest<CrmEntityListRequestArgs, ListResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.List, builder.BuildArgs());
        }

        public async Task<ListResponse<TCustomEntity>> List<TCustomEntity>(Action<IListRequestBuilder<TCustomEntity>> builderFunc) where TCustomEntity : AbstractEntity
        {
            var builder = new ListRequestBuilder<TCustomEntity>();
            builderFunc(builder);
            return await client.SendPostRequest<CrmEntityListRequestArgs, ListResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.List, builder.BuildArgs());
        }

        public async Task<TEntity> First(Action<IListRequestBuilder<TEntity>> builderFunc)
        {
            var builder = new ListRequestBuilder<TEntity>();
            builderFunc(builder);
            return (await client.SendPostRequest<CrmEntityListRequestArgs, ListResponse<TEntity>>(entityTypePrefix, EntityMethod.List, builder.BuildArgs())).Result.FirstOrDefault();
        }

        public async Task<TCustomEntity> First<TCustomEntity>(Action<IListRequestBuilder<TCustomEntity>> builderFunc) where TCustomEntity : AbstractEntity
        {
            var builder = new ListRequestBuilder<TCustomEntity>();
            builderFunc(builder);
            return (await client.SendPostRequest<CrmEntityListRequestArgs, ListResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.List, builder.BuildArgs())).Result.FirstOrDefault();
        }

        public async Task<GetResponse<TEntity>> Get(int id, params Expression<Func<TEntity, object>>[] fieldsExpr)
        {
            return await client.SendPostRequest<CrmEntityGetRequestArgs, GetResponse<TEntity>>(entityTypePrefix, EntityMethod.Get, new CrmEntityGetRequestArgs
            {
                Id = id,
                Fields = fieldsExpr.Select(x => x.JsonPropertyName()).ToList()
            });
        }

        public async Task<GetResponse<TCustomEntity>> Get<TCustomEntity>(int id, params Expression<Func<TCustomEntity, object>>[] fieldsExpr) where TCustomEntity : class
        {
            return await client.SendPostRequest<CrmEntityGetRequestArgs, GetResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.Get, new CrmEntityGetRequestArgs
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

        public async Task<UpdateResponse> Update(int id, Action<IUpdateRequestBuilder<TEntity>> builderFunc)
        {
            var builder = new UpdateRequestBuilder<TEntity>();
            builder.SetId(id);
            builderFunc(builder);
            return await client.SendPostRequest<CrmEntityUpdateArgs, UpdateResponse>(entityTypePrefix, EntityMethod.Update, builder.BuildArgs());
        }

        public async Task<UpdateResponse> Update<TCustomEntity>(int id, Action<IUpdateRequestBuilder<TCustomEntity>> builderFunc)
        {
            var builder = new UpdateRequestBuilder<TCustomEntity>();
            builder.SetId(id);
            builderFunc(builder);
            return await client.SendPostRequest<CrmEntityUpdateArgs, UpdateResponse>(entityTypePrefix, EntityMethod.Update, builder.BuildArgs());
        }

        public async Task<AddResponse> Add()
        {
            var builder = new AddRequestBuilder<TEntity>();
            return await client.SendPostRequest<CrmEntityAddArgs, AddResponse>(entityTypePrefix, EntityMethod.Add, builder.BuildArgs());
        }

        public async Task<AddResponse> Add(Action<IAddRequestBuilder<TEntity>> builderFunc)
        {
            var builder = new AddRequestBuilder<TEntity>();
            builderFunc(builder);
            return await client.SendPostRequest<CrmEntityAddArgs, AddResponse>(entityTypePrefix, EntityMethod.Add, builder.BuildArgs());
        }

        public async Task<AddResponse> Add<TCustomEntity>(Action<IAddRequestBuilder<TCustomEntity>> builderFunc)
        {
            var builder = new AddRequestBuilder<TCustomEntity>();
            builderFunc(builder);
            return await client.SendPostRequest<CrmEntityAddArgs, AddResponse>(entityTypePrefix, EntityMethod.Add, builder.BuildArgs());
        }
    }
}
