using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Bitrix24RestApiClient.Api;
using Bitrix24RestApiClient.Core.Models;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Api.Crm.CrmContact.Models;
using Xunit;
using Bitrix24RestApiClient.Test.Utilities;

namespace Bitrix24RestApiClient.Test.Tests.RequestBodyTests
{
    public class ContactTests : IDisposable
    {
        [Theory]
        [JsonFileData("TestData\\сontact.json", "ListTest")]
        public async Task ListTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            int id = 100;
            var bitrix24 = new Bitrix24(client);
            var items = await bitrix24.Crm.Contacts
                            .List<Contact>(x=> x
                                .AddSelect(x=>x.Id, x=>x.Name)
                                .AddFilter(x=>x.Id, id, FilterOperator.GreateThan)
                                .AddOrderBy(x => x.Id));

            Assert.True(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs));
        }

        [Theory]
        [JsonFileData("TestData\\сontact.json", "GetTest")]
        public async Task GetTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            int id = 100;
            var bitrix24 = new Bitrix24(client);
            var item = await bitrix24.Crm.Contacts
                            .Get<Contact>(id, x => x.Id, x => x.Name);

            Assert.True(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs));
        }

        [Theory]
        [JsonFileData("TestData\\сontact.json", "DeleteTest")]
        public async Task DeleteTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            int id = 100;
            var bitrix24 = new Bitrix24(client);
            var item = await bitrix24.Crm.Contacts
                            .Delete(id);

            Assert.True(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs));
        }

        [Theory]
        [JsonFileData("TestData\\сontact.json", "UpdateTest")]
        public async Task UpdateTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            int id = 100;
            var bitrix24 = new Bitrix24(client);
            var item = await bitrix24.Crm.Contacts
                            .Update<Contact>(id, x=> x.SetField(y=>y.Name, "12"));

            Assert.True(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs), $"Expected: {JsonConvert.SerializeObject(expectedObj)}, Actual: {client.LastRequestArgs}");
        }

        [Theory]
        [JsonFileData("TestData\\сontact.json", "AddTest")]
        public async Task AddTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            var bitrix24 = new Bitrix24(client);
            var item = await bitrix24.Crm.Contacts
                            .Add<Contact>(x => x.SetField(y => y.Name, "12"));

            Assert.True(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs), $"Expected: {JsonConvert.SerializeObject(expectedObj)}, Actual: {client.LastRequestArgs}");
        }

        [Theory]
        [JsonFileData("TestData\\сontact.json", "UpdateWithPhonesAndEmailsTest")]
        public async Task UpdateWithPhonesAndEmailsTest(object expectedObj)
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

            Assert.True(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs), $"Expected: {JsonConvert.SerializeObject(expectedObj)}, Actual: {client.LastRequestArgs}");
        }

        [Theory]
        [JsonFileData("TestData\\сontact.json", "AddWithPhonesAndEmailsTest")]
        public async Task AddWithPhonesAndEmailsTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            var bitrix24 = new Bitrix24(client);
            var item = await bitrix24.Crm.Contacts
                            .Add<Contact>(x =>
                                x.SetField(y => y.Name, "12")
                                .AddEmails(x => x.SetField("test@test.ru", EmailType.Рабочий))
                                .AddPhones(x => x.SetField("+79222222222", PhoneType.Рабочий))
                                );

            Assert.True(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs), $"Expected: {JsonConvert.SerializeObject(expectedObj)}, Actual: {client.LastRequestArgs}");
        }

        public void Dispose()
        {
        }
    }
}
