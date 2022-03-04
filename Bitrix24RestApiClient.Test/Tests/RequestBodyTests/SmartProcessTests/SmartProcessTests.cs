using Xunit;
using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Bitrix24RestApiClient.Api;
using Bitrix24RestApiClient.Core.Models;
using Bitrix24RestApiClient.Test.Utilities;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Core.Models.RequestArgs;
using Bitrix24RestApiClient.Api.Crm.CrmCompany.Models;

namespace Bitrix24RestApiClient.Test.Tests.RequestBodyTests
{
    public class SmartProcessTests : IDisposable
    {

        [Theory]
        [JsonFileData("Tests\\RequestBodyTests\\SmartProcessTests\\SmartProcessTests.json", nameof(ListTest))]
        public async Task ListTest(CrmEntityListRequestArgs expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            int id = 100;
            var bitrix24 = new Bitrix24(client);
            var items = await bitrix24.Crm.SmartProcesses
                            .ByEntityId(EntityTypeIdEnum.Company.EntityTypeId)
                            .List<Company>(x=> x
                                .AddSelect(x=>x.Id, x=>x.Title)
                                .AddFilter(x=>x.Id, id, FilterOperator.GreateThan)
                                .AddOrderBy(x => x.Id));

            Assert.True(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs));
        }

        [Theory]
        [JsonFileData("Tests\\RequestBodyTests\\SmartProcessTests\\SmartProcessTests.json", "GetTest")]
        public async Task GetTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            int id = 100;
            var bitrix24 = new Bitrix24(client);
            var item = await bitrix24.Crm.SmartProcesses
                            .ByEntityId(EntityTypeIdEnum.Company.EntityTypeId)
                            .Get<Company>(id, x => x.Id, x => x.Title);

            Assert.True(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs));
        }

        [Theory]
        [JsonFileData("Tests\\RequestBodyTests\\SmartProcessTests\\SmartProcessTests.json", "DeleteTest")]
        public async Task DeleteTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            int id = 100;
            var bitrix24 = new Bitrix24(client);
            var item = await bitrix24.Crm.SmartProcesses
                            .ByEntityId(EntityTypeIdEnum.Company.EntityTypeId)
                            .Delete(id);

            Assert.True(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs));
        }

        [Theory]
        [JsonFileData("Tests\\RequestBodyTests\\SmartProcessTests\\SmartProcessTests.json", "UpdateTest")]
        public async Task UpdateTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            int id = 100;
            var bitrix24 = new Bitrix24(client);
            var item = await bitrix24.Crm.SmartProcesses
                            .ByEntityId(EntityTypeIdEnum.Company.EntityTypeId)
                            .Update<Company>(id, x=> x.SetField(y=>y.Title, "12"));

            Assert.True(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs), $"Expected: {JsonConvert.SerializeObject(expectedObj)}, Actual: {client.LastRequestArgs}");
        }

        [Theory]
        [JsonFileData("Tests\\RequestBodyTests\\SmartProcessTests\\SmartProcessTests.json", "AddTest")]
        public async Task AddTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            var bitrix24 = new Bitrix24(client);
            var item = await bitrix24.Crm.SmartProcesses
                            .ByEntityId(EntityTypeIdEnum.Company.EntityTypeId)
                            .Add<Company>(x => x.SetField(y => y.Title, "12"));

            Assert.True(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs), $"Expected: {JsonConvert.SerializeObject(expectedObj)}, Actual: {client.LastRequestArgs}");
        }

        public void Dispose()
        {
        }
    }
}
