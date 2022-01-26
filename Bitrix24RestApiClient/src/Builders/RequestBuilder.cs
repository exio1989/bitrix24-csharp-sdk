using Bitrix24ApiClient.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bitrix24ApiClient.src.Builders
{
    public class RequestBuilder<TEntity>
    {
        private EntityType entityType;
        private ListRequestArgs args = new ListRequestArgs();
        private Bitrix24Client client;
        private Dictionary<string, object> fieldsToAddOrUpdate = new Dictionary<string, object>();
        private CrmMultiFieldBuilder phonesBuilder = new CrmMultiFieldBuilder();
        private CrmMultiFieldBuilder emailsBuilder = new CrmMultiFieldBuilder();

        public RequestBuilder<TEntity> SetField(string fieldName, string value)
        {
            fieldsToAddOrUpdate[fieldName] = value;
            return this;
        }

        public RequestBuilder<TEntity> WithEntityType(EntityType entityType)
        {
            this.entityType = entityType;
            return this;
        }

        public RequestBuilder<TEntity> AddPhones(Action<CrmMultiFieldBuilder> builderFunc)
        {
            builderFunc(phonesBuilder);
            return this;
        }

        public RequestBuilder<TEntity> AddEmails(Action<CrmMultiFieldBuilder> builderFunc)
        {
            builderFunc(emailsBuilder);
            return this;
        }

        public RequestBuilder<TEntity> WithFilter(string name, string value, FilterOperator op = FilterOperator.Equal)
        {
            args.Filter.Add(new Filter(name, value, op));
            return this;
        }

        public RequestBuilder<TEntity> WithClient(Bitrix24Client client)
        {
            this.client = client;
            return this;
        }

        public RequestBuilder<TEntity> WithOrder(string name, OrderDirection dir)
        {
            args.Order.Add(new Order(name, dir));
            return this;
        }

        public RequestBuilder<TEntity> WithSelect(params string[] fieldNames)
        {
            args.Select.Clear();
            args.Select.AddRange(fieldNames);
            return this;
        }

        public RequestBuilder<TEntity> WithOffset(int start)
        {
            args.Start = start;
            return this;
        }

        public Task<TEntity> First()
        {
            return client.First<TEntity>(entityType, args);
        }

        public Task<ListResponse<TEntity>> List()
        {
            return client.List<TEntity>(entityType, args);
        }

        public Task<AddResponse> Add()
        {
            fieldsToAddOrUpdate.Add(ContactFields.Email, emailsBuilder.Get());
            fieldsToAddOrUpdate.Add(ContactFields.Phone, phonesBuilder.Get());

            return client.Add(entityType, new { fields = fieldsToAddOrUpdate });
        }

        public Task<UpdateResponse> Update(string entityId)
        {
            fieldsToAddOrUpdate.Add(ContactFields.Email, emailsBuilder.Get());
            fieldsToAddOrUpdate.Add(ContactFields.Phone, phonesBuilder.Get());

            return client.Update(entityType, new CrmEntityUpdateArgs{ Id = entityId, Fields = fieldsToAddOrUpdate });
        }

        public async Task Delete(string dealId)
        {
            await client.Delete(entityType, dealId);
        }
    }
}
