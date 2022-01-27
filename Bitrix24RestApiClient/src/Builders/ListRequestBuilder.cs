using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.src.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Bitrix24ApiClient.src.Builders
{
    public class ListRequestBuilder<TEntity>
    {
        private int? start;
        private bool selectAll;
        private Expression<Func<TEntity, object>>[] selectExpressions;
        private List<Filter> filter = new List<Filter>();
        private List<Order> order = new List<Order>();

        public ListRequestBuilder<TEntity> SetStart(int start)
        {
            this.start = start;
            return this;
        }

        public ListRequestBuilder<TEntity> AddSelect(params Expression<Func<TEntity, object>>[] fields)
        {
            selectExpressions = fields;
            return this;
        }

        public ListRequestBuilder<TEntity> AddOrderBy(Expression<Func<TEntity, object>> fieldExpr)
        {
            order.Add(new Order(fieldExpr.JsonPropertyName(), OrderDirection.ASC));
            return this;
        }

        public ListRequestBuilder<TEntity> AddOrderByDesc(Expression<Func<TEntity, object>> fieldExpr)
        {
            order.Add(new Order(fieldExpr.JsonPropertyName(), OrderDirection.DESC));
            return this;
        }

        public ListRequestBuilder<TEntity> AddFilter(Expression<Func<TEntity, object>> nameExpr, object value, FilterOperator op = FilterOperator.Equal)
        {
            filter.Add(new Filter
            {
                Name = nameExpr.JsonPropertyName(),
                Value = value?.ToString(),
                Operator = op
            });
            return this;
        }

        public ListRequestBuilder<TEntity> SelectAll()
        {
            selectAll = true;
            return this;
        }

        public CrmEntityListRequestArgs BuildArgs()
        {
            List<string> select = selectExpressions.Select(x => x.JsonPropertyName()).ToList();
            if (selectAll)
                select.Add("*");

            return new CrmEntityListRequestArgs(new ListRequestArgs
            {
                Select = select,
                Order = order,
                Filter = filter,
                Start = start
            });
        }
    }
}
