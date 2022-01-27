using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.src.Utilities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bitrix24ApiClient.src.Builders
{
    public class UpdateRequestBuilder<TEntity>
    {
        private int id;
        private Dictionary<string, object> fields = new Dictionary<string, object>();
        private PhoneListBuilder phonesBuilder = new PhoneListBuilder();
        private EmailListBuilder emailsBuilder = new EmailListBuilder();

        public UpdateRequestBuilder<TEntity> SetId(int id)
        {
            this.id = id;
            return this;
        }

        public UpdateRequestBuilder<TEntity> SetField(Expression<Func<TEntity, object>> fieldNameExpr, string value)
        {
            fields[fieldNameExpr.JsonPropertyName()] = value;
            return this;
        }

        public UpdateRequestBuilder<TEntity> AddPhones(Action<PhoneListBuilder> builderFunc)
        {
            builderFunc(phonesBuilder);
            return this;
        }

        public UpdateRequestBuilder<TEntity> AddEmails(Action<EmailListBuilder> builderFunc)
        {
            builderFunc(emailsBuilder);
            return this;
        }

        public CrmEntityUpdateArgs BuildArgs()
        {
            var phones = phonesBuilder.Build();
            if (phones.Count > 0)
                fields[DealFields.Phones] = phones;

            var emails = emailsBuilder.Build();
            if (emails.Count > 0)
                fields[DealFields.Emails] = emails;

            return new CrmEntityUpdateArgs
            {
                Id = id,
                Fields = fields
            };
        }
    }
}
