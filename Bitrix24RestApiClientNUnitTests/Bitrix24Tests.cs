using Bitrix24ApiClient.src;
using Bitrix24ApiClient.src.Models;
using Bitrix24ApiClient.src.Models.Crm.Core;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Bitrix24RestApiClientNUnitTests
{
    public class Bitrix24Tests:IDisposable
    {
        [Test, TestCaseSource(typeof(JsonFileDataSource), nameof(JsonFileDataSource.GetData), 
            new object[]{ "TestData\\test-data.json", "Bitrix24Tests_ListDealTest" })]
        public async Task ListDealTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            int id = 100;
            var bitrix24 = new Bitrix24(client);
            var items = await bitrix24.Deals
                            .List<Deal>(x=> x
                                .AddSelect(x=>x.Id, x=>x.CategoryId)
                                .AddFilter(x=>x.Id, id, FilterOperator.GreateThan)
                                .AddOrderBy(x => x.Id));

            Assert.IsTrue(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs));
        }

        [Test, TestCaseSource(typeof(JsonFileDataSource), nameof(JsonFileDataSource.GetData), 
            new object[] { "TestData\\test-data.json", "Bitrix24Tests_GetDealTest" })]
        public async Task GetDealTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            int id = 100;
            var bitrix24 = new Bitrix24(client);
            var item = await bitrix24.Deals
                            .Get<Deal>(id, x => x.Id, x => x.CategoryId);

            Assert.IsTrue(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs));
        }


        [Test, TestCaseSource(typeof(JsonFileDataSource), nameof(JsonFileDataSource.GetData), 
            new object[] { "TestData\\test-data.json", "Bitrix24Tests_DeleteDealTest" })]
        public async Task DeleteDealTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            int id = 100;
            var bitrix24 = new Bitrix24(client);
            var item = await bitrix24.Deals
                            .Delete(id);

            Assert.IsTrue(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs));
        }


        [Test, TestCaseSource(typeof(JsonFileDataSource), nameof(JsonFileDataSource.GetData), 
            new object[] { "TestData\\test-data.json", "Bitrix24Tests_UpdateDealTest" })]
        public async Task UpdateDealTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            int id = 100;
            var bitrix24 = new Bitrix24(client);
            var item = await bitrix24.Deals
                            .Update<Deal>(id, x=> x.SetField(y=>y.CategoryId, "12"));

            Assert.IsTrue(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs), $"Expected: {JsonConvert.SerializeObject(expectedObj)}, Actual: {client.LastRequestArgs}");
        }


        [Test, TestCaseSource(typeof(JsonFileDataSource), nameof(JsonFileDataSource.GetData), 
            new object[] { "TestData\\test-data.json", "Bitrix24Tests_AddDealTest" })]
        public async Task AddDealTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            var bitrix24 = new Bitrix24(client);
            var item = await bitrix24.Deals
                            .Add<Deal>(x => x.SetField(y => y.CategoryId, "12"));

            Assert.IsTrue(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs), $"Expected: {JsonConvert.SerializeObject(expectedObj)}, Actual: {client.LastRequestArgs}");
        }


        [Test, TestCaseSource(typeof(JsonFileDataSource), nameof(JsonFileDataSource.GetData),
            new object[] { "TestData\\test-data.json", "Bitrix24Tests_UpdateDealWithPhonesAndEmailsTest" })]
        public async Task UpdateDealWithPhonesAndEmailsTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            int id = 100;
            var bitrix24 = new Bitrix24(client);
            var item = await bitrix24.Deals
                            .Update<Deal>(id, x => 
                                x.SetField(y => y.CategoryId, "12")
                                .AddEmails(x=>x.SetField("test@test.ru", EmailType.Рабочий))
                                .AddPhones(x => x.SetField("+79222222222", PhoneType.Рабочий))
                                );

            Assert.IsTrue(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs), $"Expected: {JsonConvert.SerializeObject(expectedObj)}, Actual: {client.LastRequestArgs}");
        }


        [Test, TestCaseSource(typeof(JsonFileDataSource), nameof(JsonFileDataSource.GetData),
            new object[] { "TestData\\test-data.json", "Bitrix24Tests_AddDealWithPhonesAndEmailsTest" })]
        public async Task AddDealWithPhonesAndEmailsTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            var bitrix24 = new Bitrix24(client);
            var item = await bitrix24.Deals
                            .Add<Deal>(x =>
                                x.SetField(y => y.CategoryId, "12")
                                .AddEmails(x => x.SetField("test@test.ru", EmailType.Рабочий))
                                .AddPhones(x => x.SetField("+79222222222", PhoneType.Рабочий))
                                );

            Assert.IsTrue(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs), $"Expected: {JsonConvert.SerializeObject(expectedObj)}, Actual: {client.LastRequestArgs}");
        }

        public void Dispose()
        {
        }
    }
}