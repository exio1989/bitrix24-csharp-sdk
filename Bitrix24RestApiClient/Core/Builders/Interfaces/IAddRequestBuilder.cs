using System;
using System.Linq.Expressions;
using Bitrix24RestApiClient.Core.Builders.Interfaces;

namespace Bitrix24RestApiClient.Core.Builders.Interfaces
{
    public interface IAddRequestBuilder<TEntity>
    {
        IAddRequestBuilder<TEntity> SetField(Expression<Func<TEntity, object>> fieldNameExpr, object value);
        IAddRequestBuilder<TEntity> AddPhones(Action<IPhoneListBuilder> builderFunc);
        IAddRequestBuilder<TEntity> AddEmails(Action<IEmailListBuilder> builderFunc);
    }
}
