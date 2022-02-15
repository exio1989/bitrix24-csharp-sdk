using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClientNUnitTests.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Bitrix24RestApiClientNUnitTests.Tests.IntegrationTests
{
    public class BatchOperationsTests : AbstractTest
    {
        [Test]
        public async Task ListGetStrategyTest()
        {
            IAsyncEnumerable<Deal> items = bitrix24.Crm.Deals.BatchOperations.ListGetStrategy.ListAll<Deal>(x=>x
                .AddFilter(y=>y.DateModify, "2022-02-01", FilterOperator.GreateThanOrEqual)
                .AddFilter(y => y.DateModify, "2022-02-02", FilterOperator.LessThan));

            List<Deal> deals = new List<Deal>();
            await foreach (var item in items)
                deals.Add(item);
        }

        [Test]
        public async Task ListItemsStrategyTest()
        {
            IAsyncEnumerable<DealStageHistory> items = bitrix24.Crm.StageHistories.Deals.BatchOperations.ListStrategy.ListItemsAll<DealStageHistory>(x => x
                .SetEntityTypeId(EntityTypeIdEnum.Deal)
                .AddFilter(y => y.Id, 132700, FilterOperator.GreateThan));

            List<DealStageHistory> dealStageHistory = new List<DealStageHistory>();
            await foreach (var item in items)
                dealStageHistory.Add(item);
        }

        [Test]
        public async Task ListStrategyTest()
        {
            IAsyncEnumerable<Product> items = bitrix24.Crm.Products.BatchOperations.ListStrategy.ListAll<Product>(x => x
                .AddFilter(y => y.Id, 0, FilterOperator.GreateThan));

            List<Product> products = new List<Product>();
            await foreach (var item in items)
                products.Add(item);
        }
    }
}