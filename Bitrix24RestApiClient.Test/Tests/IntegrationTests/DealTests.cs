using Xunit;
using System;
using System.Linq;
using System.Threading.Tasks;
using Bitrix24RestApiClient.Core.Models.Response.FieldsResponse;
using Bitrix24RestApiClient.Core.Models.Response;
using Bitrix24RestApiClient.Api.Crm.CrmDeal.Models;
using Bitrix24RestApiClient.Test.Utilities;

namespace Bitrix24RestApiClient.Test.Tests.IntegrationTests
{
    public class DealTests : AbstractTest
    {
        [Fact]
        public async Task AddTest()
        {
            int? dealId = (await bitrix24.Crm.Deals.Add(x => x.SetField(x => x.Title, "test"))).Result;
            AllocatedDeals.Add(dealId.Value);

            Deal deal = (await bitrix24.Crm.Deals.Get(dealId.Value)).Result;
            Assert.Equal(dealId.Value, deal.Id);
        }

        [Fact]
        public async Task ListTest()
        {
            int? dealId = (await bitrix24.Crm.Deals.Add(x => x.SetField(x => x.Title, "test"))).Result;
            AllocatedDeals.Add(dealId.Value);

            ListResponse<Deal> response = await bitrix24.Crm.Deals.List(x=>x
                .AddFilter(x=>x.Id, dealId.Value)
                .AddSelect(x=>x.Title));

            Assert.Equal("test", response.Result.First().Title);
        }

        [Fact]
        public async Task FirstTest()
        {
            int? dealId = (await bitrix24.Crm.Deals.Add(x => x.SetField(x => x.Title, "test"))).Result;
            AllocatedDeals.Add(dealId.Value);

            Deal deal = await bitrix24.Crm.Deals.First(x => x
                .AddFilter(x => x.Id, dealId.Value)
                .AddSelect(x => x.Title));

            Assert.Equal("test", deal.Title);
        }

        [Fact]
        public async Task UpdateTest()
        {
            int? dealId = (await bitrix24.Crm.Deals.Add(x => x.SetField(x => x.Title, "fizz"))).Result;
            AllocatedDeals.Add(dealId.Value);

            await bitrix24.Crm.Deals.Update(dealId.Value, x => x.SetField(x => x.Title, "buzz"));

            Deal deal = (await bitrix24.Crm.Deals.Get(dealId.Value, x=>x.Title)).Result;
            Assert.Equal("buzz", deal.Title);
        }

        [Fact]
        public async Task FieldsTest()
        {
            FieldsResponse fields = (await bitrix24.Crm.Deals.Fields());
        }

        [Fact]
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
