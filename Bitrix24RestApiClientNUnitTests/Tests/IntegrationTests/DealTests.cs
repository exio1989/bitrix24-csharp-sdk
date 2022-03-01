using Bitrix24RestApiClientNUnitTests.Utilities;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using Bitrix24RestApiClient.Core.Models.Response.FieldsResponse;
using Bitrix24RestApiClient.Core.Models.Response;
using Bitrix24RestApiClient.Api.Crm.CrmDeal.Models;

namespace Bitrix24RestApiClientNUnitTests.Tests.IntegrationTests
{
    public class DealTests : AbstractTest
    {
        [Test]
        public async Task AddTest()
        {
            int? dealId = (await bitrix24.Crm.Deals.Add(x => x.SetField(x => x.Title, "test"))).Result;
            AllocatedDeals.Add(dealId.Value);

            Deal deal = (await bitrix24.Crm.Deals.Get(dealId.Value)).Result;
            Assert.AreEqual(dealId.Value, deal.Id);
        }

        [Test]
        public async Task ListTest()
        {
            int? dealId = (await bitrix24.Crm.Deals.Add(x => x.SetField(x => x.Title, "test"))).Result;
            AllocatedDeals.Add(dealId.Value);

            ListResponse<Deal> response = await bitrix24.Crm.Deals.List(x=>x
                .AddFilter(x=>x.Id, dealId.Value)
                .AddSelect(x=>x.Title));

            Assert.AreEqual("test", response.Result.First().Title);
        }

        [Test]
        public async Task FirstTest()
        {
            int? dealId = (await bitrix24.Crm.Deals.Add(x => x.SetField(x => x.Title, "test"))).Result;
            AllocatedDeals.Add(dealId.Value);

            Deal deal = await bitrix24.Crm.Deals.First(x => x
                .AddFilter(x => x.Id, dealId.Value)
                .AddSelect(x => x.Title));

            Assert.AreEqual("test", deal.Title);
        }

        [Test]
        public async Task UpdateTest()
        {
            int? dealId = (await bitrix24.Crm.Deals.Add(x => x.SetField(x => x.Title, "fizz"))).Result;
            AllocatedDeals.Add(dealId.Value);

            await bitrix24.Crm.Deals.Update(dealId.Value, x => x.SetField(x => x.Title, "buzz"));

            Deal deal = (await bitrix24.Crm.Deals.Get(dealId.Value, x=>x.Title)).Result;
            Assert.AreEqual("buzz", deal.Title);
        }

        [Test]
        public async Task FieldsTest()
        {
            FieldsResponse fields = (await bitrix24.Crm.Deals.Fields());
        }

        [Test]
        public async Task DeleteTest()
        {
            int? dealId = (await bitrix24.Crm.Deals.Add(x => x.SetField(x => x.Title, "test"))).Result;

            DeleteResponse deleteResponse = (await bitrix24.Crm.Deals.Delete(dealId.Value));

            Assert.ThrowsAsync<Exception>(async ()=>
            {
                Deal deal = (await bitrix24.Crm.Deals.Get(dealId.Value)).Result;
            });
        }
    }
}