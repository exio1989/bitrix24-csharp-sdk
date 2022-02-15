using Bitrix24ApiClient.src.Builders;
using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;
using Bitrix24RestApiClient.src.Utilities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bitrix24ApiClient.Api.User
{
    //TODO Не проверено 
    public class Users
    {
        private IBitrix24Client client;
        private string entityTypePrefix = EntryPointPrefix.User;

        public Users(IBitrix24Client client)
        {
            this.client = client;
        }

        public async Task<ListResponse<TEntity>> Search<TEntity>()
        {
            var builder = new SearchRequestBuilder<TEntity>();
            return await client.SendPostRequest<CrmSearchRequestArgs, ListResponse<TEntity>>(entityTypePrefix, EntityMethod.Search, builder.BuildArgs());
        }

        public async Task<ListResponse<TEntity>> Search<TEntity>(Action<ISearchRequestBuilder<TEntity>> builderFunc)
        {
            var builder = new SearchRequestBuilder<TEntity>();
            builderFunc(builder);
            return await client.SendPostRequest<CrmSearchRequestArgs, ListResponse<TEntity>>(entityTypePrefix, EntityMethod.Search, builder.BuildArgs());
        }

        public async Task<TEntity> First<TEntity>(Action<ISearchRequestBuilder<TEntity>> builderFunc)
        {
            var builder = new SearchRequestBuilder<TEntity>();
            builderFunc(builder);
            return (await client.SendPostRequest<CrmSearchRequestArgs, ListResponse<TEntity>>(entityTypePrefix, EntityMethod.Search, builder.BuildArgs())).Result.FirstOrDefault();
        }

        public async Task<TEntity> Get<TEntity>(int id, params Expression<Func<TEntity, object>>[] fieldsExpr) where TEntity : class
        {
            return await client.SendPostRequest<CrmEntityGetRequestArgs, TEntity>(entityTypePrefix, EntityMethod.Get, new CrmEntityGetRequestArgs
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

        public async Task<UpdateResponse> Update<TEntity>(int id, Action<IUpdateRequestBuilder<TEntity>> builderFunc)
        {
            var builder = new UpdateRequestBuilder<TEntity>();
            builder.SetId(id);
            builderFunc(builder);
            return await client.SendPostRequest<CrmEntityUpdateArgs, UpdateResponse>(entityTypePrefix, EntityMethod.Update, builder.BuildArgs());
        }

        public async Task<AddResponse> Add<TEntity>(Action<IAddRequestBuilder<TEntity>> builderFunc)
        {
            var builder = new AddRequestBuilder<TEntity>();
            builderFunc(builder);
            return await client.SendPostRequest<CrmEntityAddArgs, AddResponse>(entityTypePrefix, EntityMethod.Add, builder.BuildArgs());
        }
    }
}
