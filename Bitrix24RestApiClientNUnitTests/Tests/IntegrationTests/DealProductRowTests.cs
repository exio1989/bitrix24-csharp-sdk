using Bitrix24RestApiClient.Api.Crm.Invoices.OldInvoices.Models;
using Bitrix24RestApiClientNUnitTests.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bitrix24RestApiClient.Core.Models.Response.BatchResponse;
using Bitrix24RestApiClient.Api.Crm.CrmDeal.ProductRows.Models;

namespace Bitrix24RestApiClientNUnitTests.Tests.IntegrationTests
{
    public class DealProductRowTests : AbstractTest
    {
        [Test]
        public async Task SetTest()
        {
            int? dealId = (await bitrix24.Crm.Deals.Add(x => x.SetField(x => x.Title, "test"))).Result;
            AllocatedDeals.Add(dealId.Value);

            await bitrix24.Crm.Deals.ProductRows.Set(dealId.Value, new List<DealProductRow>
            {
                new DealProductRow
                {
                    ProductName = "Test",
                    Price = 1
                }
            });

            var actualProductRows = (await bitrix24.Crm.Deals.ProductRows.Get(dealId.Value)).Result;
            Assert.AreEqual("Test", actualProductRows.First().ProductName);
        }

        [Test]
        public async Task GetBatchTest()
        {
            int? dealId1 = (await bitrix24.Crm.Deals.Add(x => x.SetField(x => x.Title, "test"))).Result;
            AllocatedDeals.Add(dealId1.Value);
            int? dealId2 = (await bitrix24.Crm.Deals.Add(x => x.SetField(x => x.Title, "test"))).Result;
            AllocatedDeals.Add(dealId2.Value);

            await bitrix24.Crm.Deals.ProductRows.Set(dealId1.Value, new List<DealProductRow>
            {
                new DealProductRow
                {
                    ProductName = "Test",
                    Price = 1
                }
            });

            await bitrix24.Crm.Deals.ProductRows.Set(dealId2.Value, new List<DealProductRow>
            {
                new DealProductRow
                {
                    ProductName = "Test",
                    Price = 1
                }
            });

            IAsyncEnumerable<ByIdBatchResponseItem<List<DealProductRow>>> prodactRowsIterator = bitrix24.Crm.Deals.ProductRows.GetByDealIds(new List<int> { dealId1.Value, dealId2.Value });
            var prodactRows = new List<ByIdBatchResponseItem<List<DealProductRow>>>();
            await foreach (var prodactRow in prodactRowsIterator)
                prodactRows.Add(prodactRow);
        }
    }
}