using Xunit;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Bitrix24RestApiClient.Test.Utilities;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Core.Models.Response;
using Bitrix24RestApiClient.Api.Crm.CrmDeal.Models;
using Bitrix24RestApiClient.Core.Models.Response.FieldsResponse;
using Bitrix24RestApiClient.Api.Crm.Item.CrmProductRow.Models;

namespace Bitrix24RestApiClient.Test.Tests.IntegrationTests
{
    /// <summary>
    /// Тесты в этом разделе сильно зависят от кастомных смарт процессов, так что просто так у вас их прогнать не получится, пока не создадите смарт процесс и не пропишете в тестах ай ди шку смарт процесса
    /// </summary>
    public class ProductRowNewTests : AbstractTest
    {
        [Fact]
        public async Task SetTest()
        {
            int entityTypeId = 179;
            string entityTypeCode = "Tb3";
            dynamic addedItem = (await bitrix24.Crm.SmartProcesses.ByEntityId(entityTypeId).Add<object>()).Result.Item;
            int id = (int)addedItem.id;

            var productItem = (await bitrix24.Crm.Products.List()).Result.First();

            var setResponse = await bitrix24.Crm.SmartProcesses.ProductRows.Set(entityTypeCode, id, new List<ProductRowNew>
            {
                new ProductRowNew
                {
                    Productid = productItem.Id
                }
            });

            var firstResponse = await bitrix24.Crm.SmartProcesses.ProductRows.First(x => x
                .AddFilter(y => y.Ownerid, id, Core.Models.FilterOperator.Equal)
                .AddFilter(y => y.Ownertype, entityTypeCode, Core.Models.FilterOperator.Equal));

            Assert.Equal(setResponse.Result.ProductRows.First().Id, firstResponse.Id);
        }

        [Fact]
        public async Task AddTest()
        {
            int entityTypeId = 179;
            string entityTypeCode = "Tb3";
            dynamic addedItem = (await bitrix24.Crm.SmartProcesses.ByEntityId(entityTypeId).Add<object>()).Result.Item;
            int id = (int)addedItem.id;
            
            var productItem = (await bitrix24.Crm.Products.List()).Result.First();

            var addResponse = await bitrix24.Crm.SmartProcesses.ProductRows.Add(x => x
                .SetField(y => y.Ownerid, id)
                .SetField(y => y.Ownertype, entityTypeCode)
                .SetField(y => y.Productid, productItem.Id));

            var firstResponse = await bitrix24.Crm.SmartProcesses.ProductRows.First(x => x
                .AddFilter(y => y.Ownerid, id, Core.Models.FilterOperator.Equal)
                .AddFilter(y => y.Ownertype, entityTypeCode, Core.Models.FilterOperator.Equal));

            Assert.Equal(addResponse.Result.ProductRow.Id, firstResponse.Id);
        }

        [Fact]
        public async Task ListTest()
        {
            int entityTypeId = 179;
            string entityTypeCode = "Tb3";
            dynamic addedItem = (await bitrix24.Crm.SmartProcesses.ByEntityId(entityTypeId).Add<object>()).Result.Item;
            int id = (int)addedItem.id;

            var productItem = (await bitrix24.Crm.Products.List()).Result.First();

            var addResponse = await bitrix24.Crm.SmartProcesses.ProductRows.Add(x => x
                .SetField(y => y.Ownerid, id)
                .SetField(y => y.Ownertype, entityTypeCode)
                .SetField(y => y.Productid, productItem.Id));

            var listResponse = await bitrix24.Crm.SmartProcesses.ProductRows.List(x => x
                .AddFilter(y => y.Ownerid, id, Core.Models.FilterOperator.Equal)
                .AddFilter(y => y.Ownertype, entityTypeCode, Core.Models.FilterOperator.Equal));

            Assert.Equal(addResponse.Result.ProductRow.Id, listResponse.Result.ProductRows.First().Id);
        }

        [Fact]
        public async Task UpdateTest()
        {
            int entityTypeId = 179;
            string entityTypeCode = "Tb3";
            dynamic addedItem = (await bitrix24.Crm.SmartProcesses.ByEntityId(entityTypeId).Add<object>()).Result.Item;
            int id = (int)addedItem.id;

            var productItem = (await bitrix24.Crm.Products.List()).Result.First();

            var addResponse = await bitrix24.Crm.SmartProcesses.ProductRows.Add(x => x
                .SetField(y => y.Ownerid, id)
                .SetField(y => y.Ownertype, entityTypeCode)
                .SetField(y => y.Productid, productItem.Id));

            await bitrix24.Crm.SmartProcesses.ProductRows.Update(addResponse.Result.ProductRow.Id.Value, x => x.SetField(y => y.Productname, "test"));

            var firstResponse = await bitrix24.Crm.SmartProcesses.ProductRows.First(x => x
                .AddFilter(y => y.Ownerid, id, Core.Models.FilterOperator.Equal)
                .AddFilter(y => y.Ownertype, entityTypeCode, Core.Models.FilterOperator.Equal));

            Assert.Equal("test", firstResponse.Productname);
        }

        [Fact]
        public async Task FieldsTest()
        {
            ExtFieldsResponse fields = await bitrix24.Crm.SmartProcesses.ProductRows.Fields();
        }

        [Fact]
        public async Task DeleteTest()
        {
            int entityTypeId = 179;
            string entityTypeCode = "Tb3";
            dynamic addedItem = (await bitrix24.Crm.SmartProcesses.ByEntityId(entityTypeId).Add<object>()).Result.Item;
            int id = (int)addedItem.id;

            var productItem = (await bitrix24.Crm.Products.List()).Result.First();

            var addResponse = await bitrix24.Crm.SmartProcesses.ProductRows.Add(x => x
                .SetField(y => y.Ownerid, id)
                .SetField(y => y.Ownertype, entityTypeCode)
                .SetField(y => y.Productid, productItem.Id));

            await bitrix24.Crm.SmartProcesses.ProductRows.Delete(addResponse.Result.ProductRow.Id.Value);

            var listResponse = await bitrix24.Crm.SmartProcesses.ProductRows.List(x => x
                .AddFilter(y => y.Ownerid, id, Core.Models.FilterOperator.Equal)
                .AddFilter(y => y.Ownertype, entityTypeCode, Core.Models.FilterOperator.Equal));

            Assert.Empty(listResponse.Result.ProductRows); 
        }
    }
}
