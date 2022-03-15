using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Builders;
using Bitrix24RestApiClient.Core.Utilities;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Core.Models.Response;
using Bitrix24RestApiClient.Core.Models.RequestArgs;
using Bitrix24RestApiClient.Core.Builders.Interfaces;

namespace Bitrix24RestApiClient.Api.User
{
    //TODO Не проверено 
    public class Users
    {
        private IBitrix24Client client;
        private EntryPointPrefix entityTypePrefix = EntryPointPrefix.User;

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
            var response = await client.SendPostRequest<CrmEntityGetRequestArgs, ListResponse<TEntity>>(entityTypePrefix, EntityMethod.Get, new CrmEntityGetRequestArgs
            {
                Id = id,
                Fields = fieldsExpr.Select(x => x.JsonPropertyName()).ToList()
            });
            return response.Result.FirstOrDefault();
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
            return await client.SendPostRequest<object, UpdateResponse>(entityTypePrefix, EntityMethod.Update, builder.BuildArgs(entityTypePrefix));
        }

        public async Task<AddResponse> Add<TEntity>(Action<IAddRequestBuilder<TEntity>> builderFunc)
        {
            var builder = new AddRequestBuilder<TEntity>();
            builderFunc(builder);
            return await client.SendPostRequest<CrmEntityAddArgs, AddResponse>(entityTypePrefix, EntityMethod.Add, builder.BuildArgs());
        }
    }
}
