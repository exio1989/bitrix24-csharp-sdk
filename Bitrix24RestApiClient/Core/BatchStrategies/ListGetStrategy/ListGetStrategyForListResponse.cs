using System;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Models;
using Bitrix24RestApiClient.Core.Builders;
using Bitrix24RestApiClient.Core.Utilities;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Core.Models.Response;
using Bitrix24RestApiClient.Core.Models.RequestArgs;
using Bitrix24RestApiClient.Core.Builders.Interfaces;
using Bitrix24RestApiClient.Core.Models.CrmAbstractEntity;
using Bitrix24RestApiClient.Core.Models.Response.BatchResponse;

namespace Bitrix24RestApiClient.Core.BatchStrategies
{
    public class ListGetStrategyForListResponse
    {
        private IBitrix24Client client;
        private EntryPointPrefix entityTypePrefix;

        public ListGetStrategyForListResponse(IBitrix24Client client, EntryPointPrefix entityTypePrefix)
        {
            this.client = client;
            this.entityTypePrefix = entityTypePrefix;
        }

        /// <summary>
        /// Получить список сущностей используя особую стратегию выборки элементов.
        /// Ограничения: стратегия не поддерживает сортировку элементов. Элементы вернутся кучей.
        /// Плюсы: список сущностей будет выбран за минимальное кол-во обращений к API за счет использования batch-запросов и
        /// затратит меньшее кол-во времени, чем если бы элементы выбирались стандартным способом через list-запрос.
        /// </summary>
        /// <param name="builderFunc"></param>
        /// <returns></returns>
        public async IAsyncEnumerable<TCustomEntity> ListAll<TCustomEntity>(Expression<Func<TCustomEntity, object>> idNameExpr, Action<IListAllRequestBuilder<TCustomEntity>> builderFunc) where TCustomEntity : IAbstractEntity
        {
            var builder = new ListRequestBuilder<TCustomEntity>();
            builderFunc(builder);

            ListRequestBuilder<TCustomEntity> fetchMinIdBuilder = builder.Copy();
            fetchMinIdBuilder
                .ClearOrderBy()
                .ClearSelect()
                .AddSelect(idNameExpr)
                .AddOrderBy(idNameExpr);

            ListResponse<TCustomEntity> firstListResponse = await client.SendPostRequest<CrmEntityListRequestArgs, ListResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.List, fetchMinIdBuilder.BuildArgs());
            if (firstListResponse.Total == 0)
                yield break;

            int nextMinId = firstListResponse.Result.Max(x => x.Id).Value;
            //Запросы уходят парами. Стартуем запрос на следующую страницу с айдишками и фечим сущности для предыдущей страницы 
            Task<ListResponse<TCustomEntity>> nextListResponseTask = FetchNextList(idNameExpr, fetchMinIdBuilder, nextMinId);

            await foreach (TCustomEntity item in BatchGetItems(idNameExpr, firstListResponse.Result))
                yield return item;

            for (int i = 0; i < firstListResponse.Total; i += 50)
            {
                Task.WaitAll(nextListResponseTask);
                ListResponse<TCustomEntity> listResponse = nextListResponseTask.Result;

                if (listResponse.Result.Count == 0)
                    yield break;

                nextMinId = listResponse.Result.Max(x => x.Id).Value;

                nextListResponseTask = FetchNextList(idNameExpr, fetchMinIdBuilder, nextMinId);

                await foreach (TCustomEntity item in BatchGetItems(idNameExpr, listResponse.Result))
                    yield return item;
            }
        }

        private async IAsyncEnumerable<TCustomEntity> BatchGetItems<TCustomEntity>(Expression<Func<TCustomEntity, object>> idNameExpr, List<TCustomEntity> items) where TCustomEntity : IAbstractEntity
        {
            CrmBatchRequestArgs getItemsBatch = new CrmBatchRequestArgs() 
            {
                Halt = 0,
                Commands = items
                    .Select(x => new { Id = x.Id, Cmd = $"{entityTypePrefix.Value}.{EntityMethod.Get.Value}?{ExpressionExtensions.JsonPropertyNameByExpr(idNameExpr)}={x.Id}" })
                    .ToDictionary(x => x.Id.Value.ToString(), x => x.Cmd)
            };

            BatchResponse<TCustomEntity> batchResponse = await client.SendPostRequest<CrmBatchRequestArgs, BatchResponse<TCustomEntity>>(EntryPointPrefix.Batch, EntityMethod.None, getItemsBatch);
            if (batchResponse.Result.Error.Count > 0)
                throw new Exception($"Ошибка при выполнении batch-запроса. Ответ: {JsonConvert.SerializeObject(batchResponse)}");

            foreach (TCustomEntity item in items.Select(x => batchResponse.Result.Result[x.Id.Value.ToString()]))
                yield return item;
        }

        private async Task<ListResponse<TCustomEntity>> FetchNextList<TCustomEntity>(Expression<Func<TCustomEntity, object>> idNameExpr, ListRequestBuilder<TCustomEntity> fetchMinIdBuilder, int nextMinId) where TCustomEntity : IAbstractEntity
        {
            ListRequestBuilder<TCustomEntity> fetchNextBuilder = fetchMinIdBuilder.Copy();
            fetchNextBuilder
                .SetStart(-1)
                .AddFilter(idNameExpr, nextMinId, FilterOperator.GreateThan);

            ListResponse<TCustomEntity> listResponse = await client.SendPostRequest<CrmEntityListRequestArgs, ListResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.List, fetchNextBuilder.BuildArgs());
            return listResponse;
        }
    }
}
