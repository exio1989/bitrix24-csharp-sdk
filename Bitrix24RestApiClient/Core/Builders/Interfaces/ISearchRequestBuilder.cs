using Bitrix24ApiClient.src.Models;
using System;
using System.Linq.Expressions;

namespace Bitrix24ApiClient.src.Builders
{
    public interface ISearchRequestBuilder<TEntity>
    {
        ISearchRequestBuilder<TEntity> AddFilter(Expression<Func<TEntity, object>> nameExpr, object value, FilterOperator op = FilterOperator.Equal);
    }
}
