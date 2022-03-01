using System.Threading.Tasks;
using Bitrix24RestApiClient.Core.Models.Enums;

namespace Bitrix24RestApiClient.Core.Client
{
    public interface IBitrix24Client
    {
        Task<TResponse> SendPostRequest<TArgs, TResponse>(EntryPointPrefix entityTypePrefix, EntityMethod method, TArgs args) where TResponse : class;
    }
}
