using Bitrix24ApiClient.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bitrix24ApiClient.src.Builders
{
    public class UserFieldRequestBuilder<TEntity>
    {
        private Bitrix24Client client;
        private EntityType entityType;
        private List<UserFieldListRequestBuilder> listBuilders = new List<UserFieldListRequestBuilder>();
        private Dictionary<string, string> fieldsToAddOrUpdate = new Dictionary<string, string>();

        public UserFieldRequestBuilder(Bitrix24Client client)
        {
            this.client = client;
        }

        public UserFieldRequestBuilder<TEntity> WithEntityType(EntityType entityType)
        {
            this.entityType = entityType;
            return this;
        }

        public UserFieldRequestBuilder<TEntity> SetField(string fieldName, string value)
        {
            fieldsToAddOrUpdate[fieldName] = value;
            return this;
        }

        public UserFieldRequestBuilder<TEntity> AddList(Func<UserFieldListRequestBuilder, UserFieldListRequestBuilder> builderFunc)
        {
            listBuilders.Add(builderFunc(new UserFieldListRequestBuilder()));
            return this;
        }

        public Task<TEntity> First()
        {
            return client.First<TEntity>(entityType);
        }

        public Task<ListResponse<TEntity>> List()
        {
            return client.List<TEntity>(entityType);
        }

        public Task<AddResponse> Add()
        {
            Dictionary<string, object> req = new Dictionary<string, object>();
            foreach(var field in fieldsToAddOrUpdate)
                req.Add(field.Key, field.Value);

            req.Add(UserFieldFields.List, listBuilders.Select(x=> x.Get()).ToList());

            return client.Add(entityType, req);
        }

        public Task<UpdateResponse> Update(string id)
        {
            Dictionary<string, object> fields = new Dictionary<string, object>();
            foreach (var field in fieldsToAddOrUpdate)
                fields.Add(field.Key, field.Value);

            fields.Add(UserFieldFields.List, listBuilders.Select(x => x.Get()).ToList());

            return client.Update(entityType, new CrmEntityUpdateArgs
            {
                Id = id,
                Fields = fields
            });
        }        
    }
}
