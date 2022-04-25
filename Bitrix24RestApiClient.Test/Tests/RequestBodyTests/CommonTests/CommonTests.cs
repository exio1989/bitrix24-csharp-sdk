using Xunit;
using System;
using System.Threading.Tasks;
using Bitrix24RestApiClient.Api;
using Bitrix24RestApiClient.Test.Utilities;
using Bitrix24RestApiClient.Api.Crm.CrmDeal.Models;

namespace Bitrix24RestApiClient.Test.Tests.RequestBodyTests
{
    public class CommonTests:IDisposable
    {
        [Theory]
        [JsonFileData("Tests\\RequestBodyTests\\CommonTests\\common.json", "EmptySelectFilterAndOrderListTest")]
        public async Task EmptySelectFilterAndOrderListTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            var bitrix24 = new Bitrix24(client);
            var items = await bitrix24.Crm.Deals
                            .List<Deal>();

            Assert.True(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs));
        }

        [Theory]
        [JsonFileData("Tests\\RequestBodyTests\\CommonTests\\common.json", "EmptySelectFilterAndOrderInSmartProcessesListTest")]
        public async Task EmptySelectFilterAndOrderInSmartProcessesListTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            var bitrix24 = new Bitrix24(client);
            var items = await bitrix24.Crm.SmartProcesses
                            .ByEntityId(1)
                            .List<Deal>();

            Assert.True(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs));
        }

        public void Dispose()
        {
        }
    }
}
