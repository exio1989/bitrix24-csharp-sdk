using Xunit;
using System;
using System.Linq;
using System.Threading.Tasks;
using Bitrix24RestApiClient.Core.Models.Response.FieldsResponse;
using Bitrix24RestApiClient.Core.Models.Response;
using Bitrix24RestApiClient.Api.Crm.CrmProduct.Models;
using Bitrix24RestApiClient.Test.Utilities;

namespace Bitrix24RestApiClient.Test.Tests.IntegrationTests
{
    public class ProductTests : AbstractTest
    {
        [Fact]
        public async Task AddTest()
        {
            int? productId = (await bitrix24.Crm.Products.Add(x => x.SetField(x => x.Name, "test"))).Result;
            AllocatedProducts.Add(productId.Value);

            Product product = (await bitrix24.Crm.Products.Get(productId.Value)).Result;
            Assert.Equal(productId.Value, product.Id);
        }

        [Fact]
        public async Task ListTest()
        {
            int? productId = (await bitrix24.Crm.Products.Add(x => x.SetField(x => x.Name, "test"))).Result;
            AllocatedProducts.Add(productId.Value);

            ListResponse<Product> response = await bitrix24.Crm.Products.List(x=>x
                .AddFilter(x=>x.Id, productId.Value)
                .AddSelect(x=>x.Name));

            Assert.Equal("test", response.Result.First().Name);
        }

        [Fact]
        public async Task FirstTest()
        {
            int? productId = (await bitrix24.Crm.Products.Add(x => x.SetField(x => x.Name, "test"))).Result;
            AllocatedProducts.Add(productId.Value);

            Product product = await bitrix24.Crm.Products.First(x => x
                .AddFilter(x => x.Id, productId.Value)
                .AddSelect(x => x.Name));

            Assert.Equal("test", product.Name);
        }

        [Fact]
        public async Task UpdateTest()
        {
            int? productId = (await bitrix24.Crm.Products.Add(x => x.SetField(x => x.Name, "fizz"))).Result;
            AllocatedProducts.Add(productId.Value);

            await bitrix24.Crm.Products.Update(productId.Value, x => x.SetField(x => x.Name, "buzz"));

            Product product = (await bitrix24.Crm.Products.Get(productId.Value, x=>x.Name)).Result;
            Assert.Equal("buzz", product.Name);
        }

        [Fact]
        public async Task FieldsTest()
        {
            FieldsResponse fields = (await bitrix24.Crm.Products.Fields());
        }

        [Fact]
        public async Task DeleteTest()
        {
            int? productId = (await bitrix24.Crm.Products.Add(x => x.SetField(x => x.Name, "test"))).Result;

            DeleteResponse deleteResponse = (await bitrix24.Crm.Products.Delete(productId.Value));

            Assert.ThrowsAsync<Exception>(async ()=>
            {
                Product product = (await bitrix24.Crm.Products.Get(productId.Value)).Result;
            });
        }
    }
}
