using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Models;
using Bitrix24RestApiClient.Core.Builders;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Core.Models.Response;
using Bitrix24RestApiClient.Core.Models.RequestArgs;
using Bitrix24RestApiClient.Core.Builders.Interfaces;
using Bitrix24RestApiClient.Core.Models.CrmAbstractEntity;
using Bitrix24RestApiClient.Core.Models.Response.ListItemsResponse;

namespace Bitrix24RestApiClient.Core.BatchStrategies
{
    public class ListStrategy
    {
        private IBitrix24Client client;
        private EntryPointPrefix entityTypePrefix;

        public ListStrategy(IBitrix24Client client, EntryPointPrefix entityTypePrefix)
        {
            this.client = client;
            this.entityTypePrefix = entityTypePrefix;
        }

        /// <summary>
        /// Получить список сущностей простым перебором элементов по списку с структурой ответа ListItemsResponse
        /// Ограничения: стратегия не поддерживает сортировку элементов. Элементы вернутся кучей.
        /// Плюсы: используется только list.
        /// </summary>
        /// <param name="builderFunc"></param>
        /// <returns></returns>
        public async IAsyncEnumerable<TCustomEntity> ListItemsAll<TCustomEntity>(Expression<Func<TCustomEntity, object>> idNameExpr, Action<IListAllRequestBuilder<TCustomEntity>> builderFunc, int? limit = null) where TCustomEntity : IAbstractEntity
        {
            var builder = new ListRequestBuilder<TCustomEntity>();
            builderFunc(builder);

            ListRequestBuilder<TCustomEntity> fetchMinIdBuilder = builder.Copy();
            fetchMinIdBuilder
                .ClearOrderBy()
                .ClearSelect()
                .AddOrderBy(idNameExpr);

            ListItemsResponse<TCustomEntity> firstListResponse = await client.SendPostRequest<CrmEntityListRequestArgs, ListItemsResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.List, fetchMinIdBuilder.BuildArgs());
            if (firstListResponse.Total == 0)
                yield break;

            int nextMinId = firstListResponse.Result.Items.Max(x => x.Id).Value;
            
            foreach (TCustomEntity item in firstListResponse.Result.Items)
                yield return item;

            for (int i = 0; i < firstListResponse.Total; i += 50)
            {
                var nextListResponse = await FetchNextListItems(idNameExpr, fetchMinIdBuilder, nextMinId);

                if (nextListResponse.Result.Items.Count == 0)
                    yield break;

                nextMinId = nextListResponse.Result.Items.Max(x => x.Id).Value;

                foreach (TCustomEntity item in nextListResponse.Result.Items)
                    yield return item;

                if (limit != null && i > limit.Value)
                    break;
            }
        }

        /// <summary>
        /// Получить список сущностей простым перебором элементов по списку с структурой ответа ListResponse
        /// Ограничения: стратегия не поддерживает сортировку элементов. Элементы вернутся кучей.
        /// Плюсы: используется только list.
        /// </summary>
        /// <param name="builderFunc"></param>
        /// <returns></returns>
        public async IAsyncEnumerable<TCustomEntity> ListAll<TCustomEntity>(Expression<Func<TCustomEntity, object>> idNameExpr, Action<IListAllRequestBuilder<TCustomEntity>> builderFunc, int? limit = null) where TCustomEntity : IAbstractEntity
        {
            var builder = new ListRequestBuilder<TCustomEntity>();
            builderFunc(builder);

            ListRequestBuilder<TCustomEntity> fetchMinIdBuilder = builder.Copy();
            fetchMinIdBuilder
                .ClearOrderBy()
                .ClearSelect()
                .AddOrderBy(idNameExpr);

            ListResponse<TCustomEntity> firstListResponse = await client.SendPostRequest<CrmEntityListRequestArgs, ListResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.List, fetchMinIdBuilder.BuildArgs());
            if (firstListResponse.Total == 0)
                yield break;

            int nextMinId = firstListResponse.Result.Max(x => x.Id).Value;

            foreach (TCustomEntity item in firstListResponse.Result)
                yield return item;

            for (int i = 0; i < firstListResponse.Total; i += 50)
            {
                var nextListResponse = await FetchNextList(idNameExpr, fetchMinIdBuilder, nextMinId);

                if (nextListResponse.Result.Count == 0)
                    yield break;

                nextMinId = nextListResponse.Result.Max(x => x.Id).Value;

                foreach (TCustomEntity item in nextListResponse.Result)
                    yield return item;

                if (limit != null && i > limit.Value)
                    break;
            }
        }

        private async Task<ListResponse<TCustomEntity>> FetchNextList<TCustomEntity>(Expression<Func<TCustomEntity, object>> idNameExpr, ListRequestBuilder<TCustomEntity> fetchMinIdBuilder, int nextMinId) where TCustomEntity : IAbstractEntity
        {
            ListRequestBuilder<TCustomEntity> fetchNextBuilder = fetchMinIdBuilder.Copy();
            fetchNextBuilder
                .AddFilter(idNameExpr, nextMinId, FilterOperator.GreateThan);

            ListResponse<TCustomEntity> listResponse = await client.SendPostRequest<CrmEntityListRequestArgs, ListResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.List, fetchNextBuilder.BuildArgs());
            return listResponse;
        }

        private async Task<ListItemsResponse<TCustomEntity>> FetchNextListItems<TCustomEntity>(Expression<Func<TCustomEntity, object>> idNameExpr, ListRequestBuilder<TCustomEntity> fetchMinIdBuilder, int nextMinId) where TCustomEntity : IAbstractEntity
        {
            ListRequestBuilder<TCustomEntity> fetchNextBuilder = fetchMinIdBuilder.Copy();
            fetchNextBuilder
                .AddFilter(idNameExpr, nextMinId, FilterOperator.GreateThan);

            ListItemsResponse<TCustomEntity> listResponse = await client.SendPostRequest<CrmEntityListRequestArgs, ListItemsResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.List, fetchNextBuilder.BuildArgs());
            return listResponse;
        }
    }
}
