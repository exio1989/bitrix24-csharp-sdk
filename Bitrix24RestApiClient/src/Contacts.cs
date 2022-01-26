using Bitrix24ApiClient.src.Builders;
using Bitrix24ApiClient.src.Models;
using System.Threading.Tasks;

namespace Bitrix24ApiClient.src
{
    public class Contacts
    {
        private Bitrix24Client client;

        public Contacts(Bitrix24Client client)
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
