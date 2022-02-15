using Bitrix24RestApiClientNUnitTests.Utilities;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Bitrix24RestApiClientNUnitTests.Tests.IntegrationTests
{
    public class StageHistoriesTests : AbstractTest
    {
        [Test]
        public async Task ListDealStagesTest()
        {
            var items = (await bitrix24.Crm.StageHistories.Deals.List()).Result;
        }
    }
}