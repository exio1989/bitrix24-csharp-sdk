using Bitrix24ApiClient.src.Builders;
using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;

namespace Bitrix24ApiClient.src
{
    public class Contacts
    {
        private IBitrix24Client client;

        public Contacts(IBitrix24Client client)
        {
            this.client = client;
        }

        public RequestBuilder<TEntity> WithEntityType<TEntity>()
        {
            var builder = new RequestBuilder<TEntity>();
            return builder
                .WithClient(client)
                .WithEntityType(EntityType.Contact);
        }
    }
}
