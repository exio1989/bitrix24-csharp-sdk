using Bitrix24ApiClient.src.Builders;
using Bitrix24ApiClient.src.Models;
using System;
using System.Threading.Tasks;

namespace Bitrix24ApiClient.src
{
    public class DealsUserFields
    {
        private Bitrix24Client client;

        public DealsUserFields(Bitrix24Client client)
        {
            this.client = client;
        }

        public UserFieldRequestBuilder<UserField> SetField(string fieldName, string value)
        {
            return new UserFieldRequestBuilder<UserField>(client)
                .WithEntityType(EntityType.DealUserFields)                
                .SetField(fieldName, value);
        }

        public UserFieldRequestBuilder<UserField> AddList(Func<UserFieldListRequestBuilder, UserFieldListRequestBuilder> builderFunc)
        {
            return new UserFieldRequestBuilder<UserField>(client)
                .WithEntityType(EntityType.DealUserFields)
                .AddList(builderFunc);
        }

        public Task<ListResponse<UserField>> List()
        {
            var builder = new RequestBuilder<UserField>();
            return builder
                .WithClient(client)
                .WithEntityType(EntityType.DealUserFields)
                .List();
        }
    }
}
