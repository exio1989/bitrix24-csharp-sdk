using Xunit;
using System;
using System.Linq;
using System.Threading.Tasks;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Api.Crm.CrmDeal.Models;
using Bitrix24RestApiClient.Test.Utilities;

namespace Bitrix24RestApiClient.Test.Tests.IntegrationTests
{
    public class SmartProcessesTests : AbstractTest
    {
        [Fact]
        public async Task SmartProcessesListTest()
        {
            var data = await bitrix24.Crm.SmartProcesses
                .ByEntityId(EntityTypeIdEnum.Deal.EntityTypeId)
                .List<Deal>();
        }
    }
}
