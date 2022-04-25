using System;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Builders;
using Bitrix24RestApiClient.Core.Utilities;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Core.Models.Response;
using Bitrix24RestApiClient.Core.Models.RequestArgs;
using Bitrix24RestApiClient.Core.Builders.Interfaces;
using Bitrix24RestApiClient.Api.Crm.Item.CrmProductRow.Models;
using Bitrix24RestApiClient.Core.Models.Response.FieldsResponse;
using Bitrix24RestApiClient.Core.Models.Response.ListItemsResponse;
using Bitrix24RestApiClient.Core.Models.Response.BatchResponse;
using Bitrix24RestApiClient.Core.BatchStrategies;

namespace Bitrix24RestApiClient.Api.Crm.Item.CrmProductRow
{
	/// <summary>
	/// Товарные позиции
	/// </summary>
	public class ProductRows
	{
        private IBitrix24Client client;
        private EntryPointPrefix entityTypePrefix;
        private ProductRowsBySmartProcessIdsStrategy byIdsStrategy;

        public ProductRows(IBitrix24Client client)
		{
            this.client = client;
            this.entityTypePrefix = EntryPointPrefix.CrmProductRow;
            this.byIdsStrategy = new ProductRowsBySmartProcessIdsStrategy(client);
        }

        public IAsyncEnumerable<ByIdBatchResponseItem<ListProductRowsResponseResult>> GetBySmartProcessIds(string smartProcessType, List<int> ids)
        {
            return byIdsStrategy.Get(smartProcessType, ids);
        }

        public async Task<ExtFieldsResponse> Fields() 
        {
            return await client.SendPostRequest<object, ExtFieldsResponse>(entityTypePrefix, EntityMethod.Fields, new { });
        }

        public async Task<ListProductRowsResponse> List()
        {
            var builder = new ListRequestBuilder<ProductRowNew>();
            return await client.SendPostRequest<CrmEntityListRequestArgs, ListProductRowsResponse>(entityTypePrefix, EntityMethod.List, builder.BuildArgs());
        }

        public async Task<ListProductRowsResponse> List(Action<IListRequestBuilder<ProductRowNew>> builderFunc)
        {
            var builder = new ListRequestBuilder<ProductRowNew>();
            builderFunc(builder);
            return await client.SendPostRequest<CrmEntityListRequestArgs, ListProductRowsResponse>(entityTypePrefix, EntityMethod.List, builder.BuildArgs());
        }

        public async Task<ProductRowNew> First(Action<IListRequestBuilder<ProductRowNew>> builderFunc)
        {
            var builder = new ListRequestBuilder<ProductRowNew>();
            builderFunc(builder);
            return (await client.SendPostRequest<CrmEntityListRequestArgs, ListProductRowsResponse>(entityTypePrefix, EntityMethod.List, builder.BuildArgs())).Result.ProductRows.FirstOrDefault();
        }

        public async Task<GetResponse<ProductRowNew>> Get(int id, params Expression<Func<ProductRowNew, object>>[] fieldsExpr)
        {
            return await client.SendPostRequest<CrmEntityGetRequestArgs, GetResponse<ProductRowNew>>(entityTypePrefix, EntityMethod.Get, new CrmEntityGetRequestArgs
            {
                Id = id,
                Fields = fieldsExpr.Select(x => x.JsonPropertyName()).ToList()
            });
        }

        public async Task<DeleteResponse> Delete(int id)
        {
            return await client.SendPostRequest<object, DeleteResponse>(entityTypePrefix, EntityMethod.Delete, new 
            {
                id = id
            });
        }

        public async Task<UpdateProductRowResponse> Update(int id, Action<IUpdateRequestBuilder<ProductRowNew>> builderFunc)
        {
            var builder = new UpdateRequestBuilderForItem<ProductRowNew>();
            builder.SetId(id);
            builderFunc(builder);
            return await client.SendPostRequest<object, UpdateProductRowResponse>(entityTypePrefix, EntityMethod.Update, builder.BuildArgs(entityTypePrefix));
        }

        public async Task<AddResponse> Add()
        {
            var builder = new AddRequestBuilder<ProductRowNew>();
            return await client.SendPostRequest<CrmEntityAddArgs, AddResponse>(entityTypePrefix, EntityMethod.Add, builder.BuildArgs());
        }

        public async Task<AddProductRowResponse> Add(Action<IAddRequestBuilder<ProductRowNew>> builderFunc)
        {
            var builder = new AddRequestBuilder<ProductRowNew>();
            builderFunc(builder);
            return await client.SendPostRequest<CrmEntityAddArgs, AddProductRowResponse>(entityTypePrefix, EntityMethod.Add, builder.BuildArgs());
        } 

        public async Task<SetProductRowResponse> Set(string ownerType, int ownerId, List<ProductRowNew> productRows)
        {
            return await client.SendPostRequest<CrmProductRowNewSetArgs, SetProductRowResponse>(entityTypePrefix, EntityMethod.Set, new CrmProductRowNewSetArgs
            {
                OwnerType = ownerType,
                OwnerId = ownerId,
                ProductRows = productRows
            });
        }
    }
}
