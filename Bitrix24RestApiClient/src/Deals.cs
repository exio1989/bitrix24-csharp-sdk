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
    public class Deals
    {
        private IBitrix24Client client;
        public DealsUserFields UserFields { get; private set; }
        public Deals(IBitrix24Client client)
        {
            this.client = client;
            UserFields = new DealsUserFields(client);
        }

        public RequestBuilder<TEntity> WithEntityType<TEntity>()
        {
            var builder = new RequestBuilder<TEntity>();
            return builder
                .WithClient(client)
                .WithEntityType(EntityType.Deal);
        }

        public async Task<ListResponse<TEntity>> List<TEntity>(Action<ListRequestBuilder<TEntity>> builderFunc)
        {
            var builder = new ListRequestBuilder<TEntity>();
            builderFunc(builder);
            return await client.List<TEntity>(EntityType.Deal, builder.BuildArgs());
        }

        public async Task<TEntity> First<TEntity>(Action<ListRequestBuilder<TEntity>> builderFunc)
        {
            var builder = new ListRequestBuilder<TEntity>();
            builderFunc(builder);
            return (await client.List<TEntity>(EntityType.Deal, builder.BuildArgs())).Result.FirstOrDefault();
        }

        public async Task<TEntity> Get<TEntity>(int id, params Expression<Func<TEntity, object>>[] fieldsExpr) where TEntity : class
        {
            return await client.Get<TEntity>(EntityType.Deal, new CrmEntityGetRequestArgs
            {
                Id = id,
                Fields = fieldsExpr.Select(x=>x.JsonPropertyName()).ToList()
            });
        }

        public async Task<DeleteResponse> Delete(int id)
        {
            return await client.Delete(EntityType.Deal, new CrmEntityDeleteRequestArgs
            {
                Id = id
            });
        }

        public async Task<UpdateResponse> Update<TEntity>(int id, Action<UpdateRequestBuilder<TEntity>> builderFunc)
        {
            var builder = new UpdateRequestBuilder<TEntity>();
            builder.SetId(id);
            builderFunc(builder);
            return await client.Update(EntityType.Deal, builder.BuildArgs());
        }

        public async Task<AddResponse> Add<TEntity>(Action<AddRequestBuilder<TEntity>> builderFunc)
        {
            var builder = new AddRequestBuilder<TEntity>();
            builderFunc(builder);
            return await client.Add(EntityType.Deal, builder.BuildArgs());
        }
    }
}
