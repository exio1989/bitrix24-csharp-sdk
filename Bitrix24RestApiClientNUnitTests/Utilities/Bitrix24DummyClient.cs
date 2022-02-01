using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Bitrix24RestApiClientNUnitTests
{
    public class Bitrix24DummyClient : IBitrix24Client
    {
        public string LastRequestArgs { get; set; }

        public Task<AddResponse> Add(string entityTypePrefix, CrmEntityAddArgs args)
        {
            LastRequestArgs = JsonConvert.SerializeObject(args);
            return Task.FromResult<AddResponse>(null);
        }

        public Task<FieldsResponse> Fields(string entityTypePrefix)
        {
            LastRequestArgs = JsonConvert.SerializeObject(new { });
            return Task.FromResult<FieldsResponse>(null);
        }

        public Task<DeleteResponse> Delete(string entityTypePrefix,  CrmEntityDeleteRequestArgs args)
        {
            LastRequestArgs = JsonConvert.SerializeObject(args);
            return Task.FromResult<DeleteResponse>(null);
        }

        public Task<TEntity> Get<TEntity>(string entityTypePrefix,  CrmEntityGetRequestArgs args) where TEntity : class
        {
            LastRequestArgs = JsonConvert.SerializeObject(args);
            return Task.FromResult<TEntity>(null);
        }

        public Task<ListResponse<TEntity>> List<TEntity>(string entityTypePrefix,  CrmEntityListRequestArgs args)
        {
            LastRequestArgs = JsonConvert.SerializeObject(args);
            return Task.FromResult<ListResponse<TEntity>>(null);
        }

        public Task<ListResponse<TEntity>> Search<TEntity>(string entityTypePrefix,  CrmSearchRequestArgs args)
        {
            LastRequestArgs = JsonConvert.SerializeObject(args);
            return Task.FromResult<ListResponse<TEntity>>(null);
        }

        public Task<UpdateResponse> Update(string entityTypePrefix,  CrmEntityUpdateArgs args)
        {
            LastRequestArgs = JsonConvert.SerializeObject(args);
            return Task.FromResult<UpdateResponse>(null);
        }
    }
}
