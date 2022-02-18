using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Bitrix24RestApiClientNUnitTests
{
    public class Bitrix24DummyClient : IBitrix24Client
    {
        public string LastRequestArgs { get; set; }

        public Task<TResponse> SendPostRequest<TArgs, TResponse>(EntryPointPrefix entityTypePrefix, EntityMethod method, TArgs args) where TResponse : class
        {
            LastRequestArgs = JsonConvert.SerializeObject(args);
            return Task.FromResult<TResponse>(null);
        }
    }
}
