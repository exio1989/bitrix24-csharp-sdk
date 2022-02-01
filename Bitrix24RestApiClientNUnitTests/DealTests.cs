using Bitrix24ApiClient.src;
using Bitrix24ApiClient.src.Models;
using Bitrix24ApiClient.src.Models.Crm.Core;
using Bitrix24RestApiClientNUnitTests.Utilities;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Bitrix24RestApiClientNUnitTests
{
    public class DealTests:IDisposable
    {
        [Test]
        public async Task GetFieldsTest()
        {
            string webhookUrl = "https://bitrix.persis.ru/rest/17/lkyun3zvykg9e8n1/";
            Bitrix24Client client = new Bitrix24Client(webhookUrl, new DummyLogger<Bitrix24Client>());
            var bitrix24 = new Bitrix24(client);

            FieldsResponse fields = await bitrix24.Crm.Deals.Fields();
        }

        [Test, TestCaseSource(typeof(JsonFileDataSource), nameof(JsonFileDataSource.GetData), 
            new object[]{ "TestData\\deal.json", "ListTest" })]
        public async Task ListDealTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            int id = 100;
            var bitrix24 = new Bitrix24(client);
            var items = await bitrix24.Crm.Deals
                            .List<Deal>(x=> x
                                .AddSelect(x=>x.Id, x=>x.CategoryId)
                                .AddFilter(x=>x.Id, id, FilterOperator.GreateThan)
                                .AddOrderBy(x => x.Id));

            Assert.IsTrue(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs));
        }

        [Test, TestCaseSource(typeof(JsonFileDataSource), nameof(JsonFileDataSource.GetData), 
            new object[] { "TestData\\deal.json", "GetTest" })]
        public async Task GetDealTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            int id = 100;
            var bitrix24 = new Bitrix24(client);
            var item = await bitrix24.Crm.Deals
                            .Get<Deal>(id, x => x.Id, x => x.CategoryId);

            Assert.IsTrue(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs));
        }


        [Test, TestCaseSource(typeof(JsonFileDataSource), nameof(JsonFileDataSource.GetData), 
            new object[] { "TestData\\deal.json", "DeleteTest" })]
        public async Task DeleteDealTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            int id = 100;
            var bitrix24 = new Bitrix24(client);
            var item = await bitrix24.Crm.Deals
                            .Delete(id);

            Assert.IsTrue(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs));
        }


        [Test, TestCaseSource(typeof(JsonFileDataSource), nameof(JsonFileDataSource.GetData), 
            new object[] { "TestData\\deal.json", "UpdateTest" })]
        public async Task UpdateDealTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            int id = 100;
            var bitrix24 = new Bitrix24(client);
            var item = await bitrix24.Crm.Deals
                            .Update<Deal>(id, x=> x.SetField(y=>y.CategoryId, "12"));

            Assert.IsTrue(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs), $"Expected: {JsonConvert.SerializeObject(expectedObj)}, Actual: {client.LastRequestArgs}");
        }


        [Test, TestCaseSource(typeof(JsonFileDataSource), nameof(JsonFileDataSource.GetData), 
            new object[] { "TestData\\deal.json", "AddTest" })]
        public async Task AddDealTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            var bitrix24 = new Bitrix24(client);
            var item = await bitrix24.Crm.Deals
                            .Add<Deal>(x => x.SetField(y => y.CategoryId, "12"));

            Assert.IsTrue(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs), $"Expected: {JsonConvert.SerializeObject(expectedObj)}, Actual: {client.LastRequestArgs}");
        }


        [Test, TestCaseSource(typeof(JsonFileDataSource), nameof(JsonFileDataSource.GetData),
            new object[] { "TestData\\deal.json", "UpdateWithPhonesAndEmailsTest" })]
        public async Task UpdateDealWithPhonesAndEmailsTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            int id = 100;
            var bitrix24 = new Bitrix24(client);
            var item = await bitrix24.Crm.Deals
                            .Update<Deal>(id, x => 
                                x.SetField(y => y.CategoryId, "12")
                                .AddEmails(x=>x.SetField("test@test.ru", EmailType.Рабочий))
                                .AddPhones(x => x.SetField("+79222222222", PhoneType.Рабочий))
                                );

            Assert.IsTrue(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs), $"Expected: {JsonConvert.SerializeObject(expectedObj)}, Actual: {client.LastRequestArgs}");
        }


        [Test, TestCaseSource(typeof(JsonFileDataSource), nameof(JsonFileDataSource.GetData),
            new object[] { "TestData\\deal.json", "AddWithPhonesAndEmailsTest" })]
        public async Task AddDealWithPhonesAndEmailsTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            var bitrix24 = new Bitrix24(client);
            var item = await bitrix24.Crm.Deals
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