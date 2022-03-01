using System;
using System.Linq;
using System.Threading.Tasks;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Builders;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Core.Models.Response;
using Bitrix24RestApiClient.Core.Models.RequestArgs;
using Bitrix24RestApiClient.Core.Builders.Interfaces;
using Bitrix24RestApiClient.Api.Crm.CrmPaySystem.Models;
using Bitrix24RestApiClient.Core.Models.CrmAbstractEntity;
using Bitrix24RestApiClient.Core.Models.Response.FieldsResponse;

namespace Bitrix24RestApiClient.Api.Crm.CrmPaySystem
{
    public class PaySystemContainer
    {
        private EntryPointPrefix entityTypePrefix = EntryPointPrefix.PaySystem;
        private IBitrix24Client client;

        public PaySystemContainer(IBitrix24Client client)
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

        public async Task<ListResponse<TCustomEntity>> List<TCustomEntity>() where TCustomEntity : IAbstractEntity
        {
            var builder = new ListRequestBuilder<TCustomEntity>();
            return await client.SendPostRequest<CrmEntityListRequestArgs, ListResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.List, builder.BuildArgs());
        }

        public async Task<ListResponse<TCustomEntity>> List<TCustomEntity>(Action<IListRequestBuilder<TCustomEntity>> builderFunc) where TCustomEntity : IAbstractEntity
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

        public async Task<TCustomEntity> First<TCustomEntity>(Action<IListRequestBuilder<TCustomEntity>> builderFunc) where TCustomEntity : IAbstractEntity
        {
            var builder = new ListRequestBuilder<TCustomEntity>();
            builderFunc(builder);
            return (await client.SendPostRequest<CrmEntityListRequestArgs, ListResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.List, builder.BuildArgs())).Result.FirstOrDefault();
        }
    }
}
