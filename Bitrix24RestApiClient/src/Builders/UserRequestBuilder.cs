using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bitrix24ApiClient.src.Builders
{
    public class UserRequestBuilder<TEntity>
    {
        private IBitrix24Client client;
        private Dictionary<string, string> fieldsToAddOrUpdate = new Dictionary<string, string>();
        private EntityType entityType;
        private List<Filter> filter = new List<Filter>();

        public UserRequestBuilder<TEntity> SetField(string fieldName, string value)
        {
            fieldsToAddOrUpdate[fieldName] = value;
            return this;
        }

        public UserRequestBuilder<TEntity> WithFilter(string name, string value, FilterOperator op = FilterOperator.Equal)
        {
            filter.Add(new Filter
            {
                Name = name,
                Value = value,
                Operator = op
            });
            return this;
        }

        public UserRequestBuilder<TEntity> WithEntityType(EntityType entityType)
        {
            this.entityType = entityType;
            return this;
        }

        public UserRequestBuilder<TEntity> WithClient(IBitrix24Client client)
        {
            this.client = client;
            return this;
        }

        public Task<ListResponse<TEntity>> Search()
        {
            return client.Search<TEntity>(entityType, new CrmSearchRequestArgs(filter));
        }
    }
}
