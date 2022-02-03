using Bitrix24ApiClient.src.Models;
using System.Threading.Tasks;

namespace Bitrix24RestApiClient.src.Models.Crm.Core.Client
{
    public interface IBitrix24Client
    {
        Task<ListResponse<TEntity>> List<TEntity>(string entityTypePrefix, CrmEntityListRequestArgs args);
        Task<TEntity> Get<TEntity>(string entityTypePrefix, CrmEntityGetRequestArgs args) where TEntity : class;
        Task<ListResponse<TEntity>> Search<TEntity>(string entityTypePrefix, CrmSearchRequestArgs args);
        Task<UpdateResponse> Update(string entityTypePrefix, CrmEntityUpdateArgs args);
        Task<AddResponse> Add(string entityTypePrefix, CrmEntityAddArgs args);
        Task<DeleteResponse> Delete(string entityTypePrefix, CrmEntityDeleteRequestArgs args);
        Task<FieldsResponse> Fields(string entityTypePrefix);
        Task<UpdateResponse> Set<TEntity>(string entityTypePrefix, CrmEntitySetArgs<TEntity> args);
        Task<TResponse> SendPostRequest<TArgs, TResponse>(string entityTypePrefix, EntityMethodEnum method, TArgs args) where TResponse : class;
    }
}
