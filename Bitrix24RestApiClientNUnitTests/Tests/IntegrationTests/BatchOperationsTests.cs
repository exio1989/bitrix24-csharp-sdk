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
        public async Task ListAllTest()
        {
            IAsyncEnumerable<Deal> items = bitrix24.Crm.Deals.BatchOperations.ListGetStrategy.ListAll<Deal>(x=>x
                .AddFilter(y=>y.DateModify, "2022-02-01", FilterOperator.GreateThanOrEqual)
                .AddFilter(y => y.DateModify, "2022-02-02", FilterOperator.LessThan));

            List<Deal> deals = new List<Deal>();
            await foreach (var item in items)
                deals.Add(item);
        }
    }
}