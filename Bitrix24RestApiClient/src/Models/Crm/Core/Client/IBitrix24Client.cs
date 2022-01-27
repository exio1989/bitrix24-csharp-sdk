using Bitrix24ApiClient.src.Models;
using System.Threading.Tasks;

namespace Bitrix24RestApiClient.src.Models.Crm.Core.Client
{
    public interface IBitrix24Client
    {
        Task<ListResponse<TEntity>> List<TEntity>(EntityType entityType, CrmEntityListRequestArgs args);
        Task<TEntity> Get<TEntity>(EntityType entityType, CrmEntityGetRequestArgs args) where TEntity : class;
        Task<ListResponse<TEntity>> Search<TEntity>(EntityType entityType, CrmSearchRequestArgs args);
        Task<UpdateResponse> Update(EntityType entityType, CrmEntityUpdateArgs args);
        Task<AddResponse> Add(EntityType entityType, CrmEntityAddArgs args);
        Task<DeleteResponse> Delete(EntityType entityType, CrmEntityDeleteRequestArgs args);
    }
}
