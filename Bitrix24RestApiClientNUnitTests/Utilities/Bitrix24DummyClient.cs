using Newtonsoft.Json;
using System.Threading.Tasks;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Models.Enums;

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
