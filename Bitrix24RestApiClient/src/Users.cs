using Bitrix24ApiClient.src.Builders;
using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;

namespace Bitrix24ApiClient.src
{
    public class Users
    {
        private IBitrix24Client client;

        public Users(IBitrix24Client client)
        {
            this.client = client;
        }

        public UserRequestBuilder<TEntity> WithEntityType<TEntity>()
        {
            var builder = new UserRequestBuilder<TEntity>();
            return builder
                .WithClient(client)
                .WithEntityType(EntityType.User);
        }
    }
}
