using Bitrix24ApiClient.src.Builders;
using Bitrix24ApiClient.src.Models;

namespace Bitrix24ApiClient.src
{
    public class Deals
    {
        private Bitrix24Client client;
        public DealsUserFields UserFields { get; private set; }
        public Deals(Bitrix24Client client)
        {
            this.client = client;
            UserFields = new DealsUserFields(client);
        }

        public RequestBuilder<TEntity> WithEntityType<TEntity>()
        {
            var builder = new RequestBuilder<TEntity>();
            return builder
                .WithClient(client)
                .WithEntityType(EntityType.Deal);
        }
    }
}
