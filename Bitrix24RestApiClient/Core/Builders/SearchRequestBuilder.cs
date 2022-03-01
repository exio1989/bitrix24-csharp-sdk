using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using Bitrix24RestApiClient.Core.Models;
using Bitrix24RestApiClient.Core.Utilities;
using Bitrix24RestApiClient.Core.Models.RequestArgs;
using Bitrix24RestApiClient.Core.Builders.Interfaces;

namespace Bitrix24RestApiClient.Core.Builders
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
