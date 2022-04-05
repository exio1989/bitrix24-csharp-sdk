using System;
using System.Linq.Expressions;
using Bitrix24RestApiClient.Core.Models;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Core.Models.CrmAbstractEntity;

namespace Bitrix24RestApiClient.Core.Builders.Interfaces
{
    public interface IListAllRequestBuilder<TEntity>
    {
        IListRequestBuilder<TEntity> SetEntityTypeId(EntityTypeIdEnum entityTypeId);
        IListAllRequestBuilder<TEntity> AddFilter(Expression<Func<TEntity, object>> nameExpr, object value, FilterOperator op = FilterOperator.Default);
        IListAllRequestBuilder<TEntity> AddPhoneFilter(string phone, FilterOperator op = FilterOperator.Default);
        IListAllRequestBuilder<TEntity> AddEmailFilter(string phone, FilterOperator op = FilterOperator.Default);
        IListRequestBuilder<TEntity> AddSelect(params Expression<Func<TEntity, object>>[] fieldsExpression);
        IListRequestBuilder<TEntity> SelectAll();
    }
}
