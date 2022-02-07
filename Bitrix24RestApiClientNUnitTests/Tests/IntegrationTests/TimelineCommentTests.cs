using Bitrix24ApiClient.src.Models;
using Bitrix24ApiClient.src.Models.Crm.Core;
using Bitrix24ApiClient.src.Models.Crm.Timeline.Comment;
using Bitrix24RestApiClientNUnitTests.Utilities;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Bitrix24RestApiClientNUnitTests.Tests.IntegrationTests
{
    public class TimelineCommentTests : AbstractTest
    {
        [Test]
        public async Task AddTest()
        {
            int? dealId = (await bitrix24.Crm.Deals.Add()).Result;
            AllocatedDeals.Add(dealId.Value);

            int? timelineCommentId = (await bitrix24.Crm.Timeline.Comments.Add(x => x
                .SetField(x=>x.EntityId, dealId)
                .SetField(x => x.EntityType, TimelineEntityType.Сделка)
                .SetField(x => x.Comment, "test"))).Result;
            AllocatedTimelineComments.Add(timelineCommentId.Value);

            TimelineComment timelineComment = (await bitrix24.Crm.Timeline.Comments.Get(timelineCommentId.Value)).Result;
            Assert.AreEqual(timelineCommentId.Value, timelineComment.Id);
        }

        [Test]
        public async Task ListTest()
        {
            int? dealId = (await bitrix24.Crm.Deals.Add()).Result;
            AllocatedDeals.Add(dealId.Value);

            int? timelineCommentId = (await bitrix24.Crm.Timeline.Comments.Add(x => x
               .SetField(x => x.EntityId, dealId)
               .SetField(x => x.EntityType, TimelineEntityType.Сделка)
               .SetField(x => x.Comment, "test"))).Result;
            AllocatedTimelineComments.Add(timelineCommentId.Value);

            ListResponse<TimelineComment> response = await bitrix24.Crm.Timeline.Comments.List(x=>x
                .AddFilter(x=>x.Id, timelineCommentId.Value)
                .AddFilter(x => x.EntityId, dealId)
                .AddFilter(x => x.EntityType, TimelineEntityType.Сделка)
                .AddSelect(x=>x.Comment));

            Assert.AreEqual("test", response.Result.First().Comment);
        }

        [Test]
        public async Task FirstTest()
        {
            int? dealId = (await bitrix24.Crm.Deals.Add()).Result;
            AllocatedDeals.Add(dealId.Value);

            int? timelineCommentId = (await bitrix24.Crm.Timeline.Comments.Add(x => x
               .SetField(x => x.EntityId, dealId)
               .SetField(x => x.EntityType, TimelineEntityType.Сделка)
               .SetField(x => x.Comment, "test"))).Result;
            AllocatedTimelineComments.Add(timelineCommentId.Value);

            TimelineComment timelineComment = await bitrix24.Crm.Timeline.Comments.First(x => x
                .AddFilter(x => x.Id, timelineCommentId.Value)
                .AddFilter(x => x.EntityId, dealId)
                .AddFilter(x => x.EntityType, TimelineEntityType.Сделка)
                .AddSelect(x => x.Comment));

            Assert.AreEqual("test", timelineComment.Comment);
        }

        [Test]
        public async Task UpdateTest()
        {
            int? dealId = (await bitrix24.Crm.Deals.Add()).Result;
            AllocatedDeals.Add(dealId.Value);

            int? timelineCommentId = (await bitrix24.Crm.Timeline.Comments.Add(x => x
               .SetField(x => x.EntityId, dealId)
               .SetField(x => x.EntityType, TimelineEntityType.Сделка)
               .SetField(x => x.Comment, "fizz"))).Result;
            AllocatedTimelineComments.Add(timelineCommentId.Value);

            await bitrix24.Crm.Timeline.Comments.Update(timelineCommentId.Value, x => x
                .SetField(x => x.EntityId, dealId)
                .SetField(x => x.EntityType, TimelineEntityType.Сделка)
                .SetField(x => x.Comment, "buzz"));

            TimelineComment timelineComment = (await bitrix24.Crm.Timeline.Comments.Get(timelineCommentId.Value, x=>x.Comment)).Result;
            Assert.AreEqual("buzz", timelineComment.Comment);
        }

        [Test]
        public async Task FieldsTest()
        {
            FieldsResponse fields = (await bitrix24.Crm.Timeline.Comments.Fields());
        }

        [Test]
        public async Task DeleteTest()
        {
            int? dealId = (await bitrix24.Crm.Deals.Add()).Result;
            AllocatedDeals.Add(dealId.Value);

            int? timelineCommentId = (await bitrix24.Crm.Timeline.Comments.Add(x => x
                .SetField(x => x.EntityId, dealId)
                .SetField(x => x.EntityType, TimelineEntityType.Сделка)
                .SetField(x => x.Comment, "fizz"))).Result;

            DeleteResponse deleteResponse = (await bitrix24.Crm.Timeline.Comments.Delete(timelineCommentId.Value));

            Assert.ThrowsAsync<Exception>(async ()=>
            {
                TimelineComment timelineComment = (await bitrix24.Crm.Timeline.Comments.Get(timelineCommentId.Value)).Result;
            });
        }
    }
}