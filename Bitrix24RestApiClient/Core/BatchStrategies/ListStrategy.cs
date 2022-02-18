using Bitrix24ApiClient.src.Builders;
using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.Core.Models;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async IAsyncEnumerable<TCustomEntity> ListItemsAll<TCustomEntity>(Action<IListAllRequestBuilder<TCustomEntity>> builderFunc, int? limit = null) where TCustomEntity : AbstractEntity
        {
            var builder = new ListRequestBuilder<TCustomEntity>();
            builderFunc(builder);

            ListRequestBuilder<TCustomEntity> fetchMinIdBuilder = builder.Copy();
            fetchMinIdBuilder
                .ClearOrderBy()
                .ClearSelect()
                .AddOrderBy(x => x.Id);

            ListItemsResponse<TCustomEntity> firstListResponse = await client.SendPostRequest<CrmEntityListRequestArgs, ListItemsResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.List, fetchMinIdBuilder.BuildArgs());
            if (firstListResponse.Total == 0)
                yield break;

            int nextMinId = firstListResponse.Result.Items.Max(x => x.Id).Value;
            
            foreach (TCustomEntity item in firstListResponse.Result.Items)
                yield return item;

            for (int i = 0; i < firstListResponse.Total; i += 50)
            {
                var nextListResponse = await FetchNextListItems(fetchMinIdBuilder, nextMinId);

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
        public async IAsyncEnumerable<TCustomEntity> ListAll<TCustomEntity>(Action<IListAllRequestBuilder<TCustomEntity>> builderFunc, int? limit = null) where TCustomEntity : AbstractEntity
        {
            var builder = new ListRequestBuilder<TCustomEntity>();
            builderFunc(builder);

            ListRequestBuilder<TCustomEntity> fetchMinIdBuilder = builder.Copy();
            fetchMinIdBuilder
                .ClearOrderBy()
                .ClearSelect()
                .AddOrderBy(x => x.Id);

            ListResponse<TCustomEntity> firstListResponse = await client.SendPostRequest<CrmEntityListRequestArgs, ListResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.List, fetchMinIdBuilder.BuildArgs());
            if (firstListResponse.Total == 0)
                yield break;

            int nextMinId = firstListResponse.Result.Max(x => x.Id).Value;

            foreach (TCustomEntity item in firstListResponse.Result)
                yield return item;

            for (int i = 0; i < firstListResponse.Total; i += 50)
            {
                var nextListResponse = await FetchNextList(fetchMinIdBuilder, nextMinId);

                if (nextListResponse.Result.Count == 0)
                    yield break;

                nextMinId = nextListResponse.Result.Max(x => x.Id).Value;

                foreach (TCustomEntity item in nextListResponse.Result)
                    yield return item;

                if (limit != null && i > limit.Value)
                    break;
            }
        }

        private async Task<ListResponse<TCustomEntity>> FetchNextList<TCustomEntity>(ListRequestBuilder<TCustomEntity> fetchMinIdBuilder, int nextMinId) where TCustomEntity : AbstractEntity
        {
            ListRequestBuilder<TCustomEntity> fetchNextBuilder = fetchMinIdBuilder.Copy();
            fetchNextBuilder
                .AddFilter(x => x.Id, nextMinId, FilterOperator.GreateThan);

            ListResponse<TCustomEntity> listResponse = await client.SendPostRequest<CrmEntityListRequestArgs, ListResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.List, fetchNextBuilder.BuildArgs());
            return listResponse;
        }

        private async Task<ListItemsResponse<TCustomEntity>> FetchNextListItems<TCustomEntity>(ListRequestBuilder<TCustomEntity> fetchMinIdBuilder, int nextMinId) where TCustomEntity : AbstractEntity
        {
            ListRequestBuilder<TCustomEntity> fetchNextBuilder = fetchMinIdBuilder.Copy();
            fetchNextBuilder
                .AddFilter(x => x.Id, nextMinId, FilterOperator.GreateThan);

            ListItemsResponse<TCustomEntity> listResponse = await client.SendPostRequest<CrmEntityListRequestArgs, ListItemsResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.List, fetchNextBuilder.BuildArgs());
            return listResponse;
        }
    }
}
