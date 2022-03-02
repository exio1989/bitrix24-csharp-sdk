using Xunit;
using System;
using System.Linq;
using System.Threading.Tasks;
using Bitrix24RestApiClient.Api.Crm.Timeline.Comment.Models;
using Bitrix24RestApiClient.Api.Crm.Timeline.Models;
using Bitrix24RestApiClient.Core.Models.Response.FieldsResponse;
using Bitrix24RestApiClient.Core.Models.Response;
using Bitrix24RestApiClient.Test.Utilities;

namespace Bitrix24RestApiClient.Test.Tests.IntegrationTests
{
    public class TimelineCommentTests : AbstractTest
    {
        [Fact]
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
            Assert.Equal(timelineCommentId.Value, timelineComment.Id);
        }

        [Fact]
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

            Assert.Equal("test", response.Result.First().Comment);
        }

        [Fact]
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

            Assert.Equal("test", timelineComment.Comment);
        }

        [Fact]
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
            Assert.Equal("buzz", timelineComment.Comment);
        }

        [Fact]
        public async Task FieldsTest()
        {
            FieldsResponse fields = (await bitrix24.Crm.Timeline.Comments.Fields());
        }

        [Fact]
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
