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
using Bitrix24RestApiClient.Core.Models.Response.AddItemResponse;
using Bitrix24RestApiClient.Core.Models.Response.ListItemsResponse;

namespace Bitrix24RestApiClient.Api.Crm.Item.CrmSmartProcessContainer
{
    public class SmartProcessContainer
    {
        private IBitrix24Client client;
        private EntryPointPrefix entityTypePrefix = EntryPointPrefix.Item;
        private int? entityTypeId;

        public SmartProcessContainer(IBitrix24Client client, int entityTypeId)
        {
            this.client = client;
            this.entityTypeId = entityTypeId;
            this.BatchOperations = new BatchOperationsForListItemsResponse(client, entityTypePrefix, entityTypeId);
        }

        public BatchOperationsForListItemsResponse BatchOperations { get; private set; } 

        public async Task<FieldsResponse> Fields()
        {
            return await client.SendPostRequest<object, FieldsResponse>(entityTypePrefix, EntityMethod.Fields, new { });
        }

        public async Task<ListItemsResponse<TCustomEntity>> List<TCustomEntity>() where TCustomEntity : IAbstractEntity
        {
            var builder = new ListRequestBuilder<TCustomEntity>();
            builder.SetEntityTypeId(entityTypeId);
            return await client.SendPostRequest<CrmEntityListRequestArgs, ListItemsResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.List, builder.BuildArgs());
        }

        public async Task<ListItemsResponse<TCustomEntity>> List<TCustomEntity>(Action<IListRequestBuilder<TCustomEntity>> builderFunc) where TCustomEntity : IAbstractEntity
        {
            var builder = new ListRequestBuilder<TCustomEntity>();
            builder.SetEntityTypeId(entityTypeId);
            builderFunc(builder);
            return await client.SendPostRequest<CrmEntityListRequestArgs, ListItemsResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.List, builder.BuildArgs());
        }

        public async Task<TCustomEntity> First<TCustomEntity>(Action<IListRequestBuilder<TCustomEntity>> builderFunc) where TCustomEntity : IAbstractEntity
        {
            var builder = new ListRequestBuilder<TCustomEntity>();
            builder.SetEntityTypeId(entityTypeId);
            builderFunc(builder);
            return (await client.SendPostRequest<CrmEntityListRequestArgs, ListItemsResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.List, builder.BuildArgs())).Result.Items.FirstOrDefault();
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

        public async Task<DeleteItemResponse> Delete(int id)
        {
            return await client.SendPostRequest<CrmEntityDeleteRequestArgs, DeleteItemResponse>(entityTypePrefix, EntityMethod.Delete, new CrmEntityDeleteRequestArgs
            {
                EntityTypeId = entityTypeId,
                Id = id
            });
        } 

        public async Task<UpdateItemResponse<TCustomEntity>> Update<TCustomEntity>(int id, Action<IUpdateRequestBuilder<TCustomEntity>> builderFunc)
        {
            var builder = new UpdateRequestBuilder<TCustomEntity>();
            builder.SetEntityTypeId(entityTypeId);
            builder.SetId(id);
            builderFunc(builder);
            return await client.SendPostRequest<object, UpdateItemResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.Update, builder.BuildArgs(entityTypePrefix));
        }

        public async Task<AddItemResponse<TCustomEntity>> Add<TCustomEntity>()
        {
            var builder = new AddRequestBuilder<TCustomEntity>();
            builder.SetEntityTypeId(entityTypeId);
            return await client.SendPostRequest<CrmEntityAddArgs, AddItemResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.Add, builder.BuildArgs());
        }

        public async Task<AddItemResponse<TCustomEntity>> Add<TCustomEntity>(Action<IAddRequestBuilder<TCustomEntity>> builderFunc)
        {
            var builder = new AddRequestBuilder<TCustomEntity>();
            builder.SetEntityTypeId(entityTypeId);
            builderFunc(builder);
            return await client.SendPostRequest<CrmEntityAddArgs, AddItemResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.Add, builder.BuildArgs());
        }
    }
}
