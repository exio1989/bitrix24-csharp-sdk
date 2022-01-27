using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Bitrix24RestApiClientNUnitTests
{
    public class Bitrix24DummyClient : IBitrix24Client
    {
        public string LastRequestArgs { get; set; }

        public Task<AddResponse> Add(EntityType entityType, CrmEntityAddArgs args)
        {
            LastRequestArgs = JsonConvert.SerializeObject(args);
            return Task.FromResult<AddResponse>(null);
        }

        public Task<DeleteResponse> Delete(EntityType entityType, CrmEntityDeleteRequestArgs args)
        {
            LastRequestArgs = JsonConvert.SerializeObject(args);
            return Task.FromResult<DeleteResponse>(null);
        }

        public Task<TEntity> Get<TEntity>(EntityType entityType, CrmEntityGetRequestArgs args) where TEntity : class
        {
            LastRequestArgs = JsonConvert.SerializeObject(args);
            return Task.FromResult<TEntity>(null);
        }

        public Task<ListResponse<TEntity>> List<TEntity>(EntityType entityType, CrmEntityListRequestArgs args)
        {
            LastRequestArgs = JsonConvert.SerializeObject(args);
            return Task.FromResult<ListResponse<TEntity>>(null);
        }

        public Task<ListResponse<TEntity>> Search<TEntity>(EntityType entityType, CrmSearchRequestArgs args)
        {
            LastRequestArgs = JsonConvert.SerializeObject(args);
            return Task.FromResult<ListResponse<TEntity>>(null);
        }

        public Task<UpdateResponse> Update(EntityType entityType, CrmEntityUpdateArgs args)
        {
            LastRequestArgs = JsonConvert.SerializeObject(args);
            return Task.FromResult<UpdateResponse>(null);
        }
    }
}
