using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bitrix24ApiClient.src.Builders
{
    public class UserFieldRequestBuilder<TEntity>
    {
        private IBitrix24Client client;
        private EntityType entityType;
        private List<UserFieldListRequestBuilder> listBuilders = new List<UserFieldListRequestBuilder>();
        private Dictionary<string, string> fieldsToAddOrUpdate = new Dictionary<string, string>();

        public UserFieldRequestBuilder(IBitrix24Client client)
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

        public async Task<TEntity> First()
        {
            return (await client.List<TEntity>(entityType, new CrmEntityListRequestArgs())).Result.FirstOrDefault();
        }

        public Task<ListResponse<TEntity>> List()
        {
            return client.List<TEntity>(entityType, new CrmEntityListRequestArgs());
        }

        public Task<AddResponse> Add()
        {
            Dictionary<string, object> req = new Dictionary<string, object>();
            foreach(var field in fieldsToAddOrUpdate)
                req.Add(field.Key, field.Value);

            req.Add(UserFieldFields.List, listBuilders.Select(x=> x.Get()).ToList());

            return client.Add(entityType, new CrmEntityAddArgs
            {
                Fields = req
            });
        }

        public Task<UpdateResponse> Update(int id)
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
