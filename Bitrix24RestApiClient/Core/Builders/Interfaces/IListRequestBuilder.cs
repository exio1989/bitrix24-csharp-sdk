using Bitrix24ApiClient.src.Models;
using System;
using System.Linq.Expressions;

namespace Bitrix24ApiClient.src.Builders
{
    public interface IListRequestBuilder<TEntity>
    {
        IListRequestBuilder<TEntity> SetStart(int start);
        IListRequestBuilder<TEntity> AddSelect(params Expression<Func<TEntity, object>>[] fieldsExpression);
        IListRequestBuilder<TEntity> SelectAll();
        IListRequestBuilder<TEntity> AddOrderBy(Expression<Func<TEntity, object>> fieldExpr);
        IListRequestBuilder<TEntity> AddOrderByDesc(Expression<Func<TEntity, object>> fieldExpr);
        IListRequestBuilder<TEntity> AddFilter(Expression<Func<TEntity, object>> nameExpr, object value, FilterOperator op = FilterOperator.Equal);
        IListRequestBuilder<TEntity> AddPhoneFilter(string phone, FilterOperator op = FilterOperator.Equal);
        IListRequestBuilder<TEntity> AddEmailFilter(string phone, FilterOperator op = FilterOperator.Equal);
    }
}
