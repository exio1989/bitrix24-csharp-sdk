using Bitrix24ApiClient.src.Builders;
using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;
using Bitrix24RestApiClient.src.Utilities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bitrix24RestApiClient.src.Core
{
    public class AbstractEntity<TEntity> where TEntity : class
    {
        private IBitrix24Client client;
        private string entityTypePrefix;

        public AbstractEntity(IBitrix24Client client, string entityTypePrefix)
        {
            this.client = client;
            this.entityTypePrefix = entityTypePrefix;
        }

        public async Task<ListResponse<TEntity>> List(Action<ListRequestBuilder<TEntity>> builderFunc)
        {
            var builder = new ListRequestBuilder<TEntity>();
            builderFunc(builder);
            return await client.List<TEntity>(entityTypePrefix, builder.BuildArgs());
        }

        public async Task<ListResponse<TCustomEntity>> List<TCustomEntity>(Action<ListRequestBuilder<TCustomEntity>> builderFunc)
        {
            var builder = new ListRequestBuilder<TCustomEntity>();
            builderFunc(builder);
            return await client.List<TCustomEntity>(entityTypePrefix, builder.BuildArgs());
        }

        public async Task<TEntity> First(Action<ListRequestBuilder<TEntity>> builderFunc)
        {
            var builder = new ListRequestBuilder<TEntity>();
            builderFunc(builder);
            return (await client.List<TEntity>(entityTypePrefix, builder.BuildArgs())).Result.FirstOrDefault();
        }

        public async Task<TCustomEntity> First<TCustomEntity>(Action<ListRequestBuilder<TCustomEntity>> builderFunc)
        {
            var builder = new ListRequestBuilder<TCustomEntity>();
            builderFunc(builder);
            return (await client.List<TCustomEntity>(entityTypePrefix, builder.BuildArgs())).Result.FirstOrDefault();
        }

        public async Task<GetResponse<TEntity>> Get(int id, params Expression<Func<TEntity, object>>[] fieldsExpr)
        {
            return await client.Get<GetResponse<TEntity>>(entityTypePrefix, new CrmEntityGetRequestArgs
            {
                Id = id,
                Fields = fieldsExpr.Select(x => x.JsonPropertyName()).ToList()
            });
        }

        public async Task<TCustomEntity> Get<TCustomEntity>(int id, params Expression<Func<TCustomEntity, object>>[] fieldsExpr) where TCustomEntity : class
        {
            return await client.Get<TCustomEntity>(entityTypePrefix, new CrmEntityGetRequestArgs
            {
                Id = id,
                Fields = fieldsExpr.Select(x => x.JsonPropertyName()).ToList()
            });
        }

        public async Task<DeleteResponse> Delete(int id)
        {
            return await client.Delete(entityTypePrefix, new CrmEntityDeleteRequestArgs
            {
                Id = id
            });
        }

        public async Task<UpdateResponse> Update(int id, Action<UpdateRequestBuilder<TEntity>> builderFunc)
        {
            var builder = new UpdateRequestBuilder<TEntity>();
            builder.SetId(id);
            builderFunc(builder);
            return await client.Update(entityTypePrefix, builder.BuildArgs());
        }

        public async Task<UpdateResponse> Update<TCustomEntity>(int id, Action<UpdateRequestBuilder<TCustomEntity>> builderFunc)
        {
            var builder = new UpdateRequestBuilder<TCustomEntity>();
            builder.SetId(id);
            builderFunc(builder);
            return await client.Update(entityTypePrefix, builder.BuildArgs());
        }

        public async Task<AddResponse> Add(Action<AddRequestBuilder<TEntity>> builderFunc)
        {
            var builder = new AddRequestBuilder<TEntity>();
            builderFunc(builder);
            return await client.Add(entityTypePrefix, builder.BuildArgs());
        }

        public async Task<AddResponse> Add<TCustomEntity>(Action<AddRequestBuilder<TCustomEntity>> builderFunc)
        {
            var builder = new AddRequestBuilder<TCustomEntity>();
            builderFunc(builder);
            return await client.Add(entityTypePrefix, builder.BuildArgs());
        }
    }
}
