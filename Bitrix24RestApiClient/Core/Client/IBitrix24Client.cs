using Bitrix24ApiClient.src.Models;
using System.Threading.Tasks;

namespace Bitrix24RestApiClient.src.Models.Crm.Core.Client
{
    public interface IBitrix24Client
    {
        Task<TResponse> SendPostRequest<TArgs, TResponse>(EntryPointPrefix entityTypePrefix, EntityMethod method, TArgs args) where TResponse : class;
    }
}
