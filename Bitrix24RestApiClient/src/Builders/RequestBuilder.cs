using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;
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
        private IBitrix24Client client;
        private Dictionary<string, object> fieldsToAddOrUpdate = new Dictionary<string, object>();
        private EmailListBuilder phonesBuilder = new EmailListBuilder();
        private EmailListBuilder emailsBuilder = new EmailListBuilder();

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

        public RequestBuilder<TEntity> AddPhones(Action<EmailListBuilder> builderFunc)
        {
            builderFunc(phonesBuilder);
            return this;
        }

        public RequestBuilder<TEntity> AddEmails(Action<EmailListBuilder> builderFunc)
        {
            builderFunc(emailsBuilder);
            return this;
        }

        public RequestBuilder<TEntity> WithFilter(string name, string value, FilterOperator op = FilterOperator.Equal)
        {
            args.Filter.Add(new Filter
            {
                Name = name,
                Value = value,
                Operator = op
            });
            return this;
        }

        public RequestBuilder<TEntity> WithClient(IBitrix24Client client)
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

        public async Task<TEntity> First()
        {
            return (await client.List<TEntity>(entityType, new CrmEntityListRequestArgs(args))).Result.FirstOrDefault();
        }

        public Task<ListResponse<TEntity>> List()
        {
            return client.List<TEntity>(entityType, new CrmEntityListRequestArgs(args));
        }

        public Task<AddResponse> Add()
        {
            fieldsToAddOrUpdate.Add(ContactFields.Email, emailsBuilder.Build());
            fieldsToAddOrUpdate.Add(ContactFields.Phone, phonesBuilder.Build());

            return client.Add(entityType, new CrmEntityAddArgs
            {
                Fields = fieldsToAddOrUpdate
            });
        }

        public Task<UpdateResponse> Update(int entityId)
        {
            fieldsToAddOrUpdate.Add(ContactFields.Email, emailsBuilder.Build());
            fieldsToAddOrUpdate.Add(ContactFields.Phone, phonesBuilder.Build());

            return client.Update(entityType, new CrmEntityUpdateArgs{ Id = entityId, Fields = fieldsToAddOrUpdate });
        }

        public async Task Delete(int dealId)
        {
            await client.Delete(entityType, new CrmEntityDeleteRequestArgs
            {
                Id = dealId
            });
        }
    }
}
