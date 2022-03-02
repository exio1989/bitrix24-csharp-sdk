using System;
using System.Linq;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Collections.Generic;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Utilities;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Core.Models.RequestArgs;
using Bitrix24RestApiClient.Core.Models.Response.BatchResponse;

namespace Bitrix24RestApiClient.Core.BatchStrategies
{
    public class ByIdsStrategy
    {
        private IBitrix24Client client;

        public ByIdsStrategy(IBitrix24Client client)
        {
            this.client = client;
        }

        public async IAsyncEnumerable<ByIdBatchResponseItem<List<TCustomEntity>>> Get<TCustomEntity>(Expression<Func<TCustomEntity, object>> idNameExpr, EntryPointPrefix entryPointPrefix, List<int> ids)
        {
            int batchSize = 50;

            for (int i = 0; i < ids.Count; i += batchSize)
            {
                var partIds = ids.GetRange(i, Math.Min(batchSize, ids.Count - i));

                await foreach (ByIdBatchResponseItem<List<TCustomEntity>> item in BatchGetItems(idNameExpr, entryPointPrefix, partIds))
                    yield return item;
            }
        } 

        private async IAsyncEnumerable<ByIdBatchResponseItem<List<TCustomEntity>>> BatchGetItems<TCustomEntity>(Expression<Func<TCustomEntity, object>> idNameExpr, EntryPointPrefix entryPointPrefix, List<int> ids)
        {
            CrmBatchRequestArgs getItemsBatch = new CrmBatchRequestArgs() 
            {
                Halt = 0,
                Commands = ids
                    .Select(x => new { Id = x, Cmd = $"{entryPointPrefix.Value}.{EntityMethod.Get.Value}?{ExpressionExtensions.JsonPropertyNameByExpr(idNameExpr)}={x}" })
                    .ToDictionary(x => x.Id.ToString(), x => x.Cmd)
            };

            BatchResponse<List<TCustomEntity>> batchResponse = await client.SendPostRequest<CrmBatchRequestArgs, BatchResponse<List<TCustomEntity>>>(EntryPointPrefix.Batch, EntityMethod.None, getItemsBatch);
            if (batchResponse.Result.Error.Count > 0)
                throw new Exception($"Ошибка при выполнении batch-запроса. Ответ: {JsonConvert.SerializeObject(batchResponse)}");

            foreach (ByIdBatchResponseItem<List<TCustomEntity>> item in ids.Select(x => new ByIdBatchResponseItem<List<TCustomEntity>>
            {
                Id = x,
                Result  = batchResponse.Result.Result[x.ToString()]
            }))
                yield return item;
        }
    }
}
