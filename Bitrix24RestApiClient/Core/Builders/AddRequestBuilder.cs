using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.src.Utilities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bitrix24ApiClient.src.Builders
{

    public class AddRequestBuilder<TEntity>: IAddRequestBuilder<TEntity>
    {
        private Dictionary<string, object> fields = new Dictionary<string, object>();
        private PhoneListBuilder phonesBuilder = new PhoneListBuilder();
        private EmailListBuilder emailsBuilder = new EmailListBuilder();

        public IAddRequestBuilder<TEntity> SetField(Expression<Func<TEntity, object>> fieldNameExpr, object value)
        {
            fields[fieldNameExpr.JsonPropertyName()] = fieldNameExpr.MapValue(value);
            return this;
        }

        public IAddRequestBuilder<TEntity> AddPhones(Action<IPhoneListBuilder> builderFunc)
        {
            builderFunc(phonesBuilder);
            return this;
        }

        public IAddRequestBuilder<TEntity> AddEmails(Action<IEmailListBuilder> builderFunc)
        {
            builderFunc(emailsBuilder);
            return this;
        }

        public CrmEntityAddArgs BuildArgs()
        {
            var phones = phonesBuilder.Build();
            if (phones.Count > 0)
                fields["PHONE"] = phones;

            var emails = emailsBuilder.Build();
            if (emails.Count > 0)
                fields["EMAIL"] = emails;

            return new CrmEntityAddArgs
            {
                Fields = fields
            };
        }
    }
}
