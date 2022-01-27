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
    //TODO Не проверено 
    public class Users
    {
        private IBitrix24Client client;
        private string entityTypePrefix = EntityTypePrefix.User;

        public Users(IBitrix24Client client)
        {
            this.client = client;
        }

        public async Task<ListResponse<TEntity>> Search<TEntity>(Action<SearchRequestBuilder<TEntity>> builderFunc)
        {
            var builder = new SearchRequestBuilder<TEntity>();
            builderFunc(builder);
            return await client.Search<TEntity>(entityTypePrefix, builder.BuildArgs());
        }

        public async Task<TEntity> First<TEntity>(Action<SearchRequestBuilder<TEntity>> builderFunc)
        {
            var builder = new SearchRequestBuilder<TEntity>();
            builderFunc(builder);
            return (await client.Search<TEntity>(entityTypePrefix, builder.BuildArgs())).Result.FirstOrDefault();
        }

        public async Task<TEntity> Get<TEntity>(int id, params Expression<Func<TEntity, object>>[] fieldsExpr) where TEntity : class
        {
            return await client.Get<TEntity>(entityTypePrefix, new CrmEntityGetRequestArgs
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

        public async Task<UpdateResponse> Update<TEntity>(int id, Action<UpdateRequestBuilder<TEntity>> builderFunc)
        {
            var builder = new UpdateRequestBuilder<TEntity>();
            builder.SetId(id);
            builderFunc(builder);
            return await client.Update(entityTypePrefix, builder.BuildArgs());
        }

        public async Task<AddResponse> Add<TEntity>(Action<AddRequestBuilder<TEntity>> builderFunc)
        {
            var builder = new AddRequestBuilder<TEntity>();
            builderFunc(builder);
            return await client.Add(entityTypePrefix, builder.BuildArgs());
        }
    }
}
