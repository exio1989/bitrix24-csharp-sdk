using System;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Threading.Tasks;
using Bitrix24RestApiClient.Api;
using Bitrix24RestApiClient.Core.Models;
using Bitrix24RestApiClient.Api.Crm.Timeline.Comment.Models;

namespace Bitrix24RestApiClientNUnitTests
{
    public class TimelineCommentTests : IDisposable
    {
        [Test, TestCaseSource(typeof(JsonFileDataSource), nameof(JsonFileDataSource.GetData), 
            new object[]{ "TestData\\timeline-comment.json", "ListTest" })]
        public async Task ListTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            int id = 100;
            var bitrix24 = new Bitrix24(client);
            var items = await bitrix24.Crm.Timeline.Comments
                            .List<TimelineComment>(x=> x
                                .AddSelect(x=>x.Id, x=>x.Comment)
                                .AddFilter(x=>x.Id, id, FilterOperator.GreateThan)
                                .AddOrderBy(x => x.Id));

            Assert.IsTrue(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs));
        }

        [Test, TestCaseSource(typeof(JsonFileDataSource), nameof(JsonFileDataSource.GetData), 
            new object[] { "TestData\\timeline-comment.json", "GetTest" })]
        public async Task GetTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            int id = 100;
            var bitrix24 = new Bitrix24(client);
            var item = await bitrix24.Crm.Timeline.Comments
                            .Get<TimelineComment>(id, x => x.Id, x => x.Comment);

            Assert.IsTrue(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs));
        }


        [Test, TestCaseSource(typeof(JsonFileDataSource), nameof(JsonFileDataSource.GetData), 
            new object[] { "TestData\\timeline-comment.json", "DeleteTest" })]
        public async Task DeleteTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            int id = 100;
            var bitrix24 = new Bitrix24(client);
            var item = await bitrix24.Crm.Timeline.Comments
                            .Delete(id);

            Assert.IsTrue(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs));
        }


        [Test, TestCaseSource(typeof(JsonFileDataSource), nameof(JsonFileDataSource.GetData), 
            new object[] { "TestData\\timeline-comment.json", "UpdateTest" })]
        public async Task UpdateTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            int id = 100;
            var bitrix24 = new Bitrix24(client);
            var item = await bitrix24.Crm.Timeline.Comments
                            .Update<TimelineComment>(id, x=> x.SetField(y=>y.Comment, "12"));

            Assert.IsTrue(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs), $"Expected: {JsonConvert.SerializeObject(expectedObj)}, Actual: {client.LastRequestArgs}");
        }


        [Test, TestCaseSource(typeof(JsonFileDataSource), nameof(JsonFileDataSource.GetData), 
            new object[] { "TestData\\timeline-comment.json", "AddTest" })]
        public async Task AddTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            var bitrix24 = new Bitrix24(client);
            var item = await bitrix24.Crm.Timeline.Comments
                            .Add<TimelineComment>(x => x.SetField(y => y.Comment, "12"));

            Assert.IsTrue(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs), $"Expected: {JsonConvert.SerializeObject(expectedObj)}, Actual: {client.LastRequestArgs}");
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}