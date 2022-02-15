using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.Core.Models;
using System;
using System.Linq.Expressions;

namespace Bitrix24ApiClient.src.Builders
{
    public interface IListAllRequestBuilder<TEntity> where TEntity : AbstractEntity
    {
        IListRequestBuilder<TEntity> SetEntityTypeId(EntityTypeIdEnum entityTypeId);
        IListAllRequestBuilder<TEntity> AddFilter(Expression<Func<TEntity, object>> nameExpr, object value, FilterOperator op = FilterOperator.Equal);
        IListAllRequestBuilder<TEntity> AddPhoneFilter(string phone, FilterOperator op = FilterOperator.Equal);
        IListAllRequestBuilder<TEntity> AddEmailFilter(string phone, FilterOperator op = FilterOperator.Equal);
        IListRequestBuilder<TEntity> AddSelect(params Expression<Func<TEntity, object>>[] fieldsExpression);
        IListRequestBuilder<TEntity> SelectAll();
    }
}
