using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.Core.Models;
using Bitrix24RestApiClient.src.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Bitrix24ApiClient.src.Builders
{

    public class ListRequestBuilder<TEntity> : IListRequestBuilder<TEntity>, IListAllRequestBuilder<TEntity> where TEntity : AbstractEntity
    {
        private int? start;
        private bool selectAll;
        private List<string> select = new List<string>();
        private List<Filter> filter = new List<Filter>();
        private List<Order> order = new List<Order>();

        public ListRequestBuilder(){
        }

        public ListRequestBuilder(int? start, bool selectAll, List<string> select, List<Filter> filter, List<Order> order)
        {
            this.start = start;
            this.selectAll = selectAll;
            this.select = select;
            this.filter = filter;
            this.order = order;
        }

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

        public IListRequestBuilder<TEntity> ClearOrderBy()
        {
            order.Clear();
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
            AddFilterInternal(nameExpr, value, op);
            return this;
        }

        IListAllRequestBuilder<TEntity> IListAllRequestBuilder<TEntity>.AddFilter(Expression<Func<TEntity, object>> nameExpr, object value, FilterOperator op)
        {
            AddFilterInternal(nameExpr, value, op);
            return this;
        }

        public IListRequestBuilder<TEntity> AddPhoneFilter(string phone, FilterOperator op = FilterOperator.Equal)
        {
            AddPhoneFilterInternal(phone, op);
            return this;
        }

        IListAllRequestBuilder<TEntity> IListAllRequestBuilder<TEntity>.AddPhoneFilter(string phone, FilterOperator op)
        {
            AddPhoneFilterInternal(phone, op);
            return this;
        }

        public IListRequestBuilder<TEntity> AddEmailFilter(string phone, FilterOperator op = FilterOperator.Equal)
        {
            AddEmailFilterInternal(phone, op);
            return this;
        }

        IListAllRequestBuilder<TEntity> IListAllRequestBuilder<TEntity>.AddEmailFilter(string phone, FilterOperator op)
        {
            AddEmailFilterInternal(phone, op);
            return this;
        }

        public IListRequestBuilder<TEntity> SelectAll()
        {
            selectAll = true;
            return this;
        }

        public ListRequestBuilder<TEntity> Copy()
        {
            return new ListRequestBuilder<TEntity>(start, selectAll, select.ToList(), filter.ToList(), order.ToList());
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

        private void AddFilterInternal(Expression<Func<TEntity, object>> nameExpr, object value, FilterOperator op)
        {
            filter.Add(new Filter
            {
                Name = nameExpr.JsonPropertyName(),
                Value = nameExpr.MapValue(value),
                Operator = op
            });
        }

        private void AddPhoneFilterInternal(string phone, FilterOperator op)
        {
            filter.Add(new Filter
            {
                Name = "PHONE",
                Value = phone,
                Operator = op
            });
        }

        private void AddEmailFilterInternal(string phone, FilterOperator op)
        {
            filter.Add(new Filter
            {
                Name = "EMAIL",
                Value = phone,
                Operator = op
            });
        }
    }
}
