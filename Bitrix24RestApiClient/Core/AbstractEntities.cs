using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Builders;
using Bitrix24RestApiClient.Core.Utilities;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Core.BatchStrategies;
using Bitrix24RestApiClient.Core.Models.Response;
using Bitrix24RestApiClient.Core.Models.RequestArgs;
using Bitrix24RestApiClient.Core.Builders.Interfaces;
using Bitrix24RestApiClient.Core.Models.CrmAbstractEntity;
using Bitrix24RestApiClient.Core.Models.Response.FieldsResponse;

namespace Bitrix24RestApiClient.Core
{
    public class AbstractEntities<TEntity> where TEntity : IAbstractEntity
    {
        private IBitrix24Client client;
        private EntryPointPrefix entityTypePrefix;
        private int? entityTypeId;

        public AbstractEntities(IBitrix24Client client, EntryPointPrefix entityTypePrefix, int? entityTypeId = null)
        {
            this.client = client;
            this.entityTypePrefix = entityTypePrefix;
            this.entityTypeId = entityTypeId;
            this.BatchOperations = new BatchOperationsForListResponse(client, entityTypePrefix);
        }

        public BatchOperationsForListResponse BatchOperations { get; private set; }

        public async Task<FieldsResponse> Fields()
        {
            return await client.SendPostRequest<object, FieldsResponse>(entityTypePrefix, EntityMethod.Fields, new { });
        }

        public async Task<ListResponse<TEntity>> List()
        {
            var builder = new ListRequestBuilder<TEntity>();
            builder.SetEntityTypeId(entityTypeId);
            return await client.SendPostRequest<CrmEntityListRequestArgs, ListResponse<TEntity>>(entityTypePrefix, EntityMethod.List, builder.BuildArgs());
        }

        public async Task<ListResponse<TEntity>> List(Action<IListRequestBuilder<TEntity>> builderFunc)
        {
            var builder = new ListRequestBuilder<TEntity>();
            builder.SetEntityTypeId(entityTypeId);
            builderFunc(builder);
            return await client.SendPostRequest<CrmEntityListRequestArgs, ListResponse<TEntity>>(entityTypePrefix, EntityMethod.List, builder.BuildArgs());
        }

        public async Task<ListResponse<TCustomEntity>> List<TCustomEntity>() where TCustomEntity: IAbstractEntity
        {
            var builder = new ListRequestBuilder<TCustomEntity>();
            builder.SetEntityTypeId(entityTypeId);
            return await client.SendPostRequest<CrmEntityListRequestArgs, ListResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.List, builder.BuildArgs());
        }

        public async Task<ListResponse<TCustomEntity>> List<TCustomEntity>(Action<IListRequestBuilder<TCustomEntity>> builderFunc) where TCustomEntity : IAbstractEntity
        {
            var builder = new ListRequestBuilder<TCustomEntity>();
            builder.SetEntityTypeId(entityTypeId);
            builderFunc(builder);
            return await client.SendPostRequest<CrmEntityListRequestArgs, ListResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.List, builder.BuildArgs());
        }

        public async Task<TEntity> First(Action<IListRequestBuilder<TEntity>> builderFunc)
        {
            var builder = new ListRequestBuilder<TEntity>();
            builder.SetEntityTypeId(entityTypeId);
            builderFunc(builder);
            return (await client.SendPostRequest<CrmEntityListRequestArgs, ListResponse<TEntity>>(entityTypePrefix, EntityMethod.List, builder.BuildArgs())).Result.FirstOrDefault();
        }

        public async Task<TCustomEntity> First<TCustomEntity>(Action<IListRequestBuilder<TCustomEntity>> builderFunc) where TCustomEntity : IAbstractEntity
        {
            var builder = new ListRequestBuilder<TCustomEntity>();
            builder.SetEntityTypeId(entityTypeId);
            builderFunc(builder);
            return (await client.SendPostRequest<CrmEntityListRequestArgs, ListResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.List, builder.BuildArgs())).Result.FirstOrDefault();
        }

        public async Task<GetResponse<TEntity>> Get(int id, params Expression<Func<TEntity, object>>[] fieldsExpr)
        {
            return await client.SendPostRequest<CrmEntityGetRequestArgs, GetResponse<TEntity>>(entityTypePrefix, EntityMethod.Get, new CrmEntityGetRequestArgs
            {
                EntityTypeId = entityTypeId,
                Id = id,
                Fields = fieldsExpr.Select(x => x.JsonPropertyName()).ToList()
            });
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

        public async Task<UpdateResponse> Update(int id, Action<IUpdateRequestBuilder<TEntity>> builderFunc)
        {
            var builder = new UpdateRequestBuilder<TEntity>();
            builder.SetEntityTypeId(entityTypeId);
            builder.SetId(id);
            builderFunc(builder);
            return await client.SendPostRequest<object, UpdateResponse>(entityTypePrefix, EntityMethod.Update, builder.BuildArgs(entityTypePrefix));
        }

        public async Task<UpdateResponse> Update<TCustomEntity>(int id, Action<IUpdateRequestBuilder<TCustomEntity>> builderFunc)
        {
            var builder = new UpdateRequestBuilder<TCustomEntity>();
            builder.SetEntityTypeId(entityTypeId);
            builder.SetId(id);
            builderFunc(builder);
            return await client.SendPostRequest<object, UpdateResponse>(entityTypePrefix, EntityMethod.Update, builder.BuildArgs(entityTypePrefix));
        }

        public async Task<AddResponse> Add()
        {
            var builder = new AddRequestBuilder<TEntity>();
            builder.SetEntityTypeId(entityTypeId);
            return await client.SendPostRequest<CrmEntityAddArgs, AddResponse>(entityTypePrefix, EntityMethod.Add, builder.BuildArgs());
        }

        public async Task<AddResponse> Add(Action<IAddRequestBuilder<TEntity>> builderFunc)
        {
            var builder = new AddRequestBuilder<TEntity>();
            builder.SetEntityTypeId(entityTypeId);
            builderFunc(builder);
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
