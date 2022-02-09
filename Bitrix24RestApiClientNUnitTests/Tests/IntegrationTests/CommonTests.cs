using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClientNUnitTests.Utilities;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Bitrix24RestApiClientNUnitTests.Tests.IntegrationTests
{
    public class CommonTests : AbstractTest
    {
        [Test]
        public async Task SetDateTimeOffsetToDateFieldTest()
        {
            DateTimeOffset expected = new DateTimeOffset(2017, 03, 04, 0, 0, 0, TimeSpan.Zero);

            int? dealId = (await bitrix24.Crm.Deals.Add(x => x
                .SetField(x => x.BeginDate, expected))).Result;
            AllocatedDeals.Add(dealId.Value);

            Deal deal = (await bitrix24.Crm.Deals.Get(dealId.Value)).Result;
            Assert.AreEqual(expected, deal.BeginDate);
        }

        [Test]
        public async Task SetDateTimeToDateFieldTest()
        {
            DateTime expected = new DateTime(2017, 03, 04, 0, 0, 0);

            int? dealId = (await bitrix24.Crm.Deals.Add(x => x
                .SetField(x => x.BeginDate, expected))).Result;
            AllocatedDeals.Add(dealId.Value);

            Deal deal = (await bitrix24.Crm.Deals.Get(dealId.Value)).Result;
            Assert.AreEqual(new DateTimeOffset(expected), deal.BeginDate);
        }



        [Test]
        public async Task SetStringToDateFieldTest()
        {
            DateTimeOffset expected = new DateTimeOffset(2017, 03, 04, 0, 0, 0, TimeSpan.Zero);

            int? dealId = (await bitrix24.Crm.Deals.Add(x => x
                .SetField(x => x.BeginDate, expected.ToString("yyyy-MM-dd HH:mm:ss")))).Result;
            AllocatedDeals.Add(dealId.Value);

            Deal deal = (await bitrix24.Crm.Deals.Get(dealId.Value)).Result;
            Assert.AreEqual(expected, deal.BeginDate);
        }
    }
}