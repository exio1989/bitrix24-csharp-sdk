using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.Api.Crm.Invoices.OldInvoices.Models;
using Bitrix24RestApiClientNUnitTests.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bitrix24RestApiClientNUnitTests.Tests.IntegrationTests
{
    public class DealProductRowTests : AbstractTest
    {
        [Test]
        public async Task SetTest()
        {
            int? dealId = (await bitrix24.Crm.Deals.Add(x => x.SetField(x => x.Title, "test"))).Result;
            AllocatedDeals.Add(dealId.Value);

            await bitrix24.Crm.Deals.ProductRows.Set(dealId.Value, new List<ProductRow>
            {
                new ProductRow
                {
                    ProductName = "Test",
                    Price = 1
                }
            });

            var actualProductRows = (await bitrix24.Crm.Deals.ProductRows.Get(dealId.Value)).Result;
            Assert.AreEqual("Test", actualProductRows.First().ProductName);
        }
    }
}