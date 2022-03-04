using Xunit;
using System;
using System.Threading.Tasks;
using Bitrix24RestApiClient.Api;
using Bitrix24RestApiClient.Test.Utilities;
using Bitrix24RestApiClient.Api.Crm.CrmDeal.Models;

namespace Bitrix24RestApiClient.Test.Tests.RequestBodyTests
{
    public class CrmFieldAttributeTests:IDisposable
    {
        [Theory]
        [JsonFileData("Tests\\RequestBodyTests\\CrmFieldAttributeTests\\crm-field-attribute.json", "YesNoTypeTest")]
        public async Task YesNoTypeTest(object expectedObj)
        {
            Bitrix24DummyClient client = new Bitrix24DummyClient();

            var bitrix24 = new Bitrix24(client); 
            var items = await bitrix24.Crm.Deals
                            .List<Deal>(x=> x
                                .AddFilter(x=>x.Closed, true)); 

            Assert.True(TestHelpers.CompareJsons(expectedObj, client.LastRequestArgs));
        }

        public void Dispose()
        {
        }
    }
}
