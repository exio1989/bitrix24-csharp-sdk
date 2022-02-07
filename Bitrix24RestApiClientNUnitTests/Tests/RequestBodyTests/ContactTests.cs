using Bitrix24ApiClient.src;
using Bitrix24ApiClient.src.Models;
using Bitrix24ApiClient.src.Models.Crm.Core;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Bitrix24RestApiClientNUnitTests
{
    public class ContactTests : IDisposable
    {
        [Test, TestCaseSource(typeof(JsonFileDataSource), nameof(JsonFileDataSource.GetData), 
            new object[]{ "TestData\\сontact.json", "ListTest" })]
        public async Task ListLeadTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            int id = 100;
            var bitrix24 = new Bitrix24(client);
            var items = await bitrix24.Crm.Contacts
                            .List<Contact>(x=> x
                                .AddSelect(x=>x.Id, x=>x.Name)
                                .AddFilter(x=>x.Id, id, FilterOperator.GreateThan)
                                .AddOrderBy(x => x.Id));

            Assert.IsTrue(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs));
        }

        [Test, TestCaseSource(typeof(JsonFileDataSource), nameof(JsonFileDataSource.GetData), 
            new object[] { "TestData\\сontact.json", "GetTest" })]
        public async Task GetLeadTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            int id = 100;
            var bitrix24 = new Bitrix24(client);
            var item = await bitrix24.Crm.Contacts
                            .Get<Contact>(id, x => x.Id, x => x.Name);

            Assert.IsTrue(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs));
        }


        [Test, TestCaseSource(typeof(JsonFileDataSource), nameof(JsonFileDataSource.GetData), 
            new object[] { "TestData\\сontact.json", "DeleteTest" })]
        public async Task DeleteLeadTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            int id = 100;
            var bitrix24 = new Bitrix24(client);
            var item = await bitrix24.Crm.Contacts
                            .Delete(id);

            Assert.IsTrue(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs));
        }


        [Test, TestCaseSource(typeof(JsonFileDataSource), nameof(JsonFileDataSource.GetData), 
            new object[] { "TestData\\сontact.json", "UpdateTest" })]
        public async Task UpdateLeadTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            int id = 100;
            var bitrix24 = new Bitrix24(client);
            var item = await bitrix24.Crm.Contacts
                            .Update<Contact>(id, x=> x.SetField(y=>y.Name, "12"));

            Assert.IsTrue(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs), $"Expected: {JsonConvert.SerializeObject(expectedObj)}, Actual: {client.LastRequestArgs}");
        }


        [Test, TestCaseSource(typeof(JsonFileDataSource), nameof(JsonFileDataSource.GetData), 
            new object[] { "TestData\\сontact.json", "AddTest" })]
        public async Task AddLeadTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            var bitrix24 = new Bitrix24(client);
            var item = await bitrix24.Crm.Contacts
                            .Add<Contact>(x => x.SetField(y => y.Name, "12"));

            Assert.IsTrue(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs), $"Expected: {JsonConvert.SerializeObject(expectedObj)}, Actual: {client.LastRequestArgs}");
        }


        [Test, TestCaseSource(typeof(JsonFileDataSource), nameof(JsonFileDataSource.GetData),
            new object[] { "TestData\\сontact.json", "UpdateWithPhonesAndEmailsTest" })]
        public async Task UpdateLeadWithPhonesAndEmailsTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            int id = 100;
            var bitrix24 = new Bitrix24(client);
            var item = await bitrix24.Crm.Contacts
                            .Update<Contact>(id, x => 
                                x.SetField(y => y.Name, "12")
                                .AddEmails(x=>x.SetField("test@test.ru", EmailType.Рабочий))
                                .AddPhones(x => x.SetField("+79222222222", PhoneType.Рабочий))
                                );

            Assert.IsTrue(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs), $"Expected: {JsonConvert.SerializeObject(expectedObj)}, Actual: {client.LastRequestArgs}");
        }


        [Test, TestCaseSource(typeof(JsonFileDataSource), nameof(JsonFileDataSource.GetData),
            new object[] { "TestData\\сontact.json", "AddWithPhonesAndEmailsTest" })]
        public async Task AddLeadWithPhonesAndEmailsTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            var bitrix24 = new Bitrix24(client);
            var item = await bitrix24.Crm.Contacts
                            .Add<Contact>(x =>
                                x.SetField(y => y.Name, "12")
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