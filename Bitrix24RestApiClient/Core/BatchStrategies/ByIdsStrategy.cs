using Bitrix24ApiClient.src.Builders;
using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.Core.Models;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bitrix24RestApiClient.Core.BatchStrategies
{
    public class ByIdsStrategy
    {
        private IBitrix24Client client;

        public ByIdsStrategy(IBitrix24Client client)
        {
            this.client = client;
        }

        public async IAsyncEnumerable<ByIdBatchResponseItem<TCustomEntity>> Get<TCustomEntity>(EntryPointPrefix entryPointPrefix, List<int> ids)
        {
            int batchSize = 50;

            for (int i = 0; i < ids.Count; i += batchSize)
            {
                var partIds = ids.GetRange(i, Math.Min(batchSize, ids.Count - i));

                await foreach (ByIdBatchResponseItem<TCustomEntity> item in BatchGetItems<TCustomEntity>(entryPointPrefix, partIds))
                    yield return item;
            }
        } 

        private async IAsyncEnumerable<ByIdBatchResponseItem<TCustomEntity>> BatchGetItems<TCustomEntity>(EntryPointPrefix entryPointPrefix, List<int> ids)
        {
            CrmBatchRequestArgs getItemsBatch = new CrmBatchRequestArgs() 
            {
                Halt = 0,
                Commands = ids
                    .Select(x => new { Id = x, Cmd = $"{entryPointPrefix.Value}.{EntityMethod.Get.Value}?ID={x}" })
                    .ToDictionary(x => x.Id.ToString(), x => x.Cmd)
            };

            BatchResponse<TCustomEntity> batchResponse = await client.SendPostRequest<CrmBatchRequestArgs, BatchResponse<TCustomEntity>>(EntryPointPrefix.Batch, EntityMethod.None, getItemsBatch);
            if (batchResponse.Result.Error.Count > 0)
                throw new Exception($"Ошибка при выполнении batch-запроса. Ответ: {JsonConvert.SerializeObject(batchResponse)}");

            foreach (ByIdBatchResponseItem<TCustomEntity> item in ids.Select(x => new ByIdBatchResponseItem<TCustomEntity>{
                Id = x,
                Result  = batchResponse.Result.Result[x.ToString()]
            }))
                yield return item;
        }
    }
}
