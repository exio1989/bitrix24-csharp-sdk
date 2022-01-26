using Bitrix24ApiClient.src.Builders;
using Bitrix24ApiClient.src.Models;

namespace Bitrix24ApiClient.src
{
    public class Users
    {
        private Bitrix24Client client;

        public Users(Bitrix24Client client)
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
