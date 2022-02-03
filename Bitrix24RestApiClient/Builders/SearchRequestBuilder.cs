using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.src.Utilities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bitrix24ApiClient.src.Builders
{

    public class SearchRequestBuilder<TEntity>: ISearchRequestBuilder<TEntity>
    {
        private List<Filter> filter = new List<Filter>();

        public ISearchRequestBuilder<TEntity> AddFilter(Expression<Func<TEntity, object>> nameExpr, object value, FilterOperator op = FilterOperator.Equal)
        {
            filter.Add(new Filter
            {
                Name = nameExpr.JsonPropertyName(),
                Value = value?.ToString(),
                Operator = op
            });
            return this;
        }

        public CrmSearchRequestArgs BuildArgs()
        {
            return new CrmSearchRequestArgs(filter);
        }
    }
}
