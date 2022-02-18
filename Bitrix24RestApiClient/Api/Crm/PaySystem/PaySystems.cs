using Bitrix24ApiClient.src.Builders;
using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.Core.Models;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Bitrix24ApiClient.src
{
    public class PaySystems
    {
        private EntryPointPrefix entityTypePrefix = EntryPointPrefix.PaySystem;
        private IBitrix24Client client;

        public PaySystems(IBitrix24Client client)
        {
            this.client = client;
        }

        public async Task<FieldsResponse> Fields()
        {
            return await client.SendPostRequest<object, FieldsResponse>(entityTypePrefix, EntityMethod.Fields, new { });
        }

        public async Task<ListResponse<PaySystem>> List()
        {
            var builder = new ListRequestBuilder<PaySystem>();
            return await client.SendPostRequest<CrmEntityListRequestArgs, ListResponse<PaySystem>>(entityTypePrefix, EntityMethod.List, builder.BuildArgs());
        }

        public async Task<ListResponse<PaySystem>> List(Action<IListRequestBuilder<PaySystem>> builderFunc)
        {
            var builder = new ListRequestBuilder<PaySystem>();
            builderFunc(builder);
            return await client.SendPostRequest<CrmEntityListRequestArgs, ListResponse<PaySystem>>(entityTypePrefix, EntityMethod.List, builder.BuildArgs());
        }

        public async Task<ListResponse<TCustomEntity>> List<TCustomEntity>() where TCustomEntity : AbstractEntity
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

        public async Task<PaySystem> First(Action<IListRequestBuilder<PaySystem>> builderFunc)
        {
            var builder = new ListRequestBuilder<PaySystem>();
            builderFunc(builder);
            return (await client.SendPostRequest<CrmEntityListRequestArgs, ListResponse<PaySystem>>(entityTypePrefix, EntityMethod.List, builder.BuildArgs())).Result.FirstOrDefault();
        }

        public async Task<TCustomEntity> First<TCustomEntity>(Action<IListRequestBuilder<TCustomEntity>> builderFunc) where TCustomEntity : AbstractEntity
        {
            var builder = new ListRequestBuilder<TCustomEntity>();
            builderFunc(builder);
            return (await client.SendPostRequest<CrmEntityListRequestArgs, ListResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.List, builder.BuildArgs())).Result.FirstOrDefault();
        }
    }
}
