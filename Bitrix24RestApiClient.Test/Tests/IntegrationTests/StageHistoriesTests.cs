using Xunit;
using System.Threading.Tasks;
using Bitrix24RestApiClient.Test.Utilities;

namespace Bitrix24RestApiClient.Test.Tests.IntegrationTests
{
    public class StageHistoriesTests : AbstractTest
    {
        [Fact]
        public async Task ListDealStagesTest()
        {
            var items = (await bitrix24.Crm.StageHistories.Deals.List()).Result;
        }
    }
}
