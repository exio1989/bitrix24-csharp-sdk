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
using Bitrix24RestApiClient.Core.Models.Response.ListItemsResponse;

namespace Bitrix24RestApiClient.Core.BatchStrategies
{
    public class ListGetStrategyForListItemsResponse
    {
        private IBitrix24Client client;
        private EntryPointPrefix entityTypePrefix;
        private int? entityTypeId;

        public ListGetStrategyForListItemsResponse(IBitrix24Client client, EntryPointPrefix entityTypePrefix, int? entityTypeId)
        {
            this.client = client;
            this.entityTypePrefix = entityTypePrefix;
            this.entityTypeId = entityTypeId;
        }

        /// <summary>
        /// Получить список сущностей используя особую стратегию выборки элементов.
        /// Ограничения: стратегия не поддерживает сортировку элементов. Элементы вернутся кучей.
        /// Плюсы: список сущностей будет выбран за минимальное кол-во обращений к API за счет использования batch-запросов и
        /// затратит меньшее кол-во времени, чем если бы элементы выбирались стандартным способом через list-запрос.
        /// </summary>
        /// <param name="builderFunc"></param>
        /// <returns></returns>
        public async IAsyncEnumerable<TCustomEntity> ListAll<TCustomEntity>(Expression<Func<TCustomEntity, object>> idNameExpr, Action<IListAllRequestBuilder<TCustomEntity>> builderFunc)
        {
            var builder = new ListRequestBuilder<TCustomEntity>(); 
            builder.SetEntityTypeId(entityTypeId);
            builderFunc(builder);

            ListRequestBuilder<TCustomEntity> fetchMinIdBuilder = builder.Copy();
            fetchMinIdBuilder
                .ClearOrderBy()
                .ClearSelect()
                .AddSelect(idNameExpr)
                .AddOrderBy(idNameExpr); 

            ListItemsResponse<TCustomEntity> firstListResponse = await client.SendPostRequest<CrmEntityListRequestArgs, ListItemsResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.List, fetchMinIdBuilder.BuildArgs());
            if (firstListResponse.Total == 0)
                yield break;

            int nextMinId = firstListResponse.Result.Items.Max(x => (int)ReflectionHelper.GetPropertyValue(idNameExpr, x));
            //Запросы уходят парами. Стартуем запрос на следующую страницу с айдишками и фечим сущности для предыдущей страницы
            Task<ListItemsResponse<TCustomEntity>> nextListResponseTask = FetchNextList(idNameExpr, fetchMinIdBuilder, nextMinId);

            await foreach (TCustomEntity item in BatchGetItems(idNameExpr, firstListResponse.Result.Items))
                yield return item;

            for (int i = 0; i < firstListResponse.Total; i += 50)
            {
                Task.WaitAll(nextListResponseTask);
                ListItemsResponse<TCustomEntity> listResponse = nextListResponseTask.Result;

                if (listResponse.Result.Items.Count == 0)
                    yield break;

                nextMinId = listResponse.Result.Items.Max(x => (int)ReflectionHelper.GetPropertyValue(idNameExpr, x));

                nextListResponseTask = FetchNextList(idNameExpr, fetchMinIdBuilder, nextMinId);

                await foreach (TCustomEntity item in BatchGetItems(idNameExpr, listResponse.Result.Items))
                    yield return item;
            }
        }

        private async IAsyncEnumerable<TCustomEntity> BatchGetItems<TCustomEntity>(Expression<Func<TCustomEntity, object>> idNameExpr, List<TCustomEntity> items)
        {
            CrmBatchRequestArgs getItemsBatch = new CrmBatchRequestArgs() 
            {
                Halt = 0,
                Commands = items
                    .Select(x => new { 
                        Id = ((int)ReflectionHelper.GetPropertyValue(idNameExpr, x)).ToString(), 
                        Cmd = $"{entityTypePrefix.Value}.{EntityMethod.Get.Value}?{ExpressionExtensions.JsonPropertyNameByExpr(idNameExpr)}={(int)ReflectionHelper.GetPropertyValue(idNameExpr, x)}&entityTypeId={entityTypeId}" })
                    .ToDictionary(x => x.Id, x => x.Cmd)
            };

            BatchResponse<GetItemResponse<TCustomEntity>> batchResponse = await client.SendPostRequest<CrmBatchRequestArgs, BatchResponse<GetItemResponse<TCustomEntity>>>(EntryPointPrefix.Batch, EntityMethod.None, getItemsBatch);
            if (batchResponse.Result.Error.Count > 0)
                throw new Exception($"Ошибка при выполнении batch-запроса. Ответ: {JsonConvert.SerializeObject(batchResponse)}");

            foreach (GetItemResponse<TCustomEntity> item in items.Select(x => batchResponse.Result.Result[((int)ReflectionHelper.GetPropertyValue(idNameExpr, x)).ToString()]))
                yield return item.Item;
        }

        private async Task<ListItemsResponse<TCustomEntity>> FetchNextList<TCustomEntity>(Expression<Func<TCustomEntity, object>> idNameExpr, ListRequestBuilder<TCustomEntity> fetchMinIdBuilder, int nextMinId)
        {
            ListRequestBuilder<TCustomEntity> fetchNextBuilder = fetchMinIdBuilder.Copy();
            fetchNextBuilder
                .SetStart(-1)
                .AddFilter(idNameExpr, nextMinId, FilterOperator.GreateThan);

            ListItemsResponse<TCustomEntity> listResponse = await client.SendPostRequest<CrmEntityListRequestArgs, ListItemsResponse<TCustomEntity>>(entityTypePrefix, EntityMethod.List, fetchNextBuilder.BuildArgs());
            return listResponse;
        }
    }
}
