using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClientNUnitTests.Utilities;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Bitrix24RestApiClientNUnitTests.Tests.IntegrationTests
{
    public class ProductTests : AbstractTest
    {
        [Test]
        public async Task AddTest()
        {
            int? productId = (await bitrix24.Crm.Products.Add(x => x.SetField(x => x.Name, "test"))).Result;
            AllocatedProducts.Add(productId.Value);

            Product product = (await bitrix24.Crm.Products.Get(productId.Value)).Result;
            Assert.AreEqual(productId.Value, product.Id);
        }

        [Test]
        public async Task ListTest()
        {
            int? productId = (await bitrix24.Crm.Products.Add(x => x.SetField(x => x.Name, "test"))).Result;
            AllocatedProducts.Add(productId.Value);

            ListResponse<Product> response = await bitrix24.Crm.Products.List(x=>x
                .AddFilter(x=>x.Id, productId.Value)
                .AddSelect(x=>x.Name));

            Assert.AreEqual("test", response.Result.First().Name);
        }

        [Test]
        public async Task FirstTest()
        {
            int? productId = (await bitrix24.Crm.Products.Add(x => x.SetField(x => x.Name, "test"))).Result;
            AllocatedProducts.Add(productId.Value);

            Product product = await bitrix24.Crm.Products.First(x => x
                .AddFilter(x => x.Id, productId.Value)
                .AddSelect(x => x.Name));

            Assert.AreEqual("test", product.Name);
        }

        [Test]
        public async Task UpdateTest()
        {
            int? productId = (await bitrix24.Crm.Products.Add(x => x.SetField(x => x.Name, "fizz"))).Result;
            AllocatedProducts.Add(productId.Value);

            await bitrix24.Crm.Products.Update(productId.Value, x => x.SetField(x => x.Name, "buzz"));

            Product product = (await bitrix24.Crm.Products.Get(productId.Value, x=>x.Name)).Result;
            Assert.AreEqual("buzz", product.Name);
        }

        [Test]
        public async Task FieldsTest()
        {
            FieldsResponse fields = (await bitrix24.Crm.Products.Fields());
        }

        [Test]
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