using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.src.Utilities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bitrix24ApiClient.src.Builders
{

    public class UpdateRequestBuilder<TEntity>: IUpdateRequestBuilder<TEntity>
    {
        private int? entityTypeId;
        private int id;
        private Dictionary<string, object> fields = new Dictionary<string, object>();
        private PhoneListBuilder phonesBuilder = new PhoneListBuilder();
        private EmailListBuilder emailsBuilder = new EmailListBuilder();

        public IUpdateRequestBuilder<TEntity> SetId(int id)
        {
            this.id = id;
            return this;
        }

        public IUpdateRequestBuilder<TEntity> SetEntityTypeId(EntityTypeIdEnum entityTypeId)
        {
            this.entityTypeId = entityTypeId.EntityTypeId;
            return this;
        }

        public IUpdateRequestBuilder<TEntity> SetEntityTypeId(int? entityTypeId)
        {
            this.entityTypeId = entityTypeId;
            return this;
        }

        public IUpdateRequestBuilder<TEntity> SetField(Expression<Func<TEntity, object>> fieldNameExpr, object value)
        {
            fields[fieldNameExpr.JsonPropertyName()] = value;
            return this;
        }

        public IUpdateRequestBuilder<TEntity> AddPhones(Action<IPhoneListBuilder> builderFunc)
        {
            builderFunc(phonesBuilder);
            return this;
        }

        public IUpdateRequestBuilder<TEntity> AddEmails(Action<IEmailListBuilder> builderFunc)
        {
            builderFunc(emailsBuilder);
            return this;
        }

        public CrmEntityUpdateArgs BuildArgs()
        {
            var phones = phonesBuilder.Build();
            if (phones.Count > 0)
                fields["PHONE"] = phones;

            var emails = emailsBuilder.Build();
            if (emails.Count > 0)
                fields["EMAIL"] = emails;

            return new CrmEntityUpdateArgs
            {
                EntityTypeId = entityTypeId,
                Id = id,
                Fields = fields
            };
        }
    }
}
