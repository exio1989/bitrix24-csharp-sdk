using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.src.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Bitrix24ApiClient.src.Builders
{

    public class ListRequestBuilder<TEntity>: IListRequestBuilder<TEntity>
    {
        private int? start;
        private bool selectAll;
        private List<string> select = new List<string>();
        private List<Filter> filter = new List<Filter>();
        private List<Order> order = new List<Order>();

        public IListRequestBuilder<TEntity> SetStart(int start)
        {
            this.start = start;
            return this;
        }

        public IListRequestBuilder<TEntity> AddSelect(params Expression<Func<TEntity, object>>[] fieldsExpression)
        {
            select = fieldsExpression.Select(x => x.JsonPropertyName()).ToList();
            return this;
        }

        public IListRequestBuilder<TEntity> AddOrderBy(Expression<Func<TEntity, object>> fieldExpr)
        {
            order.Add(new Order(fieldExpr.JsonPropertyName(), OrderDirection.ASC));
            return this;
        }

        public IListRequestBuilder<TEntity> AddOrderByDesc(Expression<Func<TEntity, object>> fieldExpr)
        {
            order.Add(new Order(fieldExpr.JsonPropertyName(), OrderDirection.DESC));
            return this;
        }

        public IListRequestBuilder<TEntity> AddFilter(Expression<Func<TEntity, object>> nameExpr, object value, FilterOperator op = FilterOperator.Equal)
        {
            filter.Add(new Filter
            {
                Name = nameExpr.JsonPropertyName(),
                Value = nameExpr.MapValue(value),
                Operator = op
            });
            return this;
        }
        public IListRequestBuilder<TEntity> AddPhoneFilter(string phone, FilterOperator op = FilterOperator.Equal)
        {
            filter.Add(new Filter
            {
                Name = "PHONE",
                Value = phone,
                Operator = op
            });
            return this;
        }

        public IListRequestBuilder<TEntity> AddEmailFilter(string phone, FilterOperator op = FilterOperator.Equal)
        {
            filter.Add(new Filter
            {
                Name = "EMAIL",
                Value = phone,
                Operator = op
            });
            return this;
        }

        public IListRequestBuilder<TEntity> SelectAll()
        {
            selectAll = true;
            return this;
        }

        public CrmEntityListRequestArgs BuildArgs()
        {
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
