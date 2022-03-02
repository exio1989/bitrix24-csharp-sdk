using Xunit;
using System;
using System.Linq;
using System.Threading.Tasks;
using Bitrix24RestApiClient.Api.Crm.CrmDeal.Models;
using Bitrix24RestApiClient.Test.Utilities;

namespace Bitrix24RestApiClient.Test.Tests.IntegrationTests
{
    public class CommonTests : AbstractTest
    {
        [Fact]
        public async Task SetDateTimeOffsetToDateFieldTest()
        {
            DateTimeOffset expected = new DateTimeOffset(2017, 03, 04, 0, 0, 0, TimeSpan.Zero);

            int? dealId = (await bitrix24.Crm.Deals.Add(x => x
                .SetField(x => x.BeginDate, expected))).Result;
            AllocatedDeals.Add(dealId.Value);

            Deal deal = (await bitrix24.Crm.Deals.Get(dealId.Value)).Result;
            Assert.Equal(expected, deal.BeginDate);
        }

        [Fact]
        public async Task SetDateTimeToDateFieldTest()
        {
            DateTime expected = new DateTime(2017, 03, 04, 0, 0, 0);

            int? dealId = (await bitrix24.Crm.Deals.Add(x => x
                .SetField(x => x.BeginDate, expected))).Result;
            AllocatedDeals.Add(dealId.Value);

            Deal deal = (await bitrix24.Crm.Deals.Get(dealId.Value)).Result;
            Assert.Equal(new DateTimeOffset(expected), deal.BeginDate);
        }



        [Fact]
        public async Task SetStringToDateFieldTest()
        {
            DateTimeOffset expected = new DateTimeOffset(2017, 03, 04, 0, 0, 0, TimeSpan.Zero);

            int? dealId = (await bitrix24.Crm.Deals.Add(x => x
                .SetField(x => x.BeginDate, expected.ToString("yyyy-MM-dd HH:mm:ss")))).Result;
            AllocatedDeals.Add(dealId.Value);

            Deal deal = (await bitrix24.Crm.Deals.Get(dealId.Value)).Result;
            Assert.Equal(expected, deal.BeginDate);
        }
    }
}
