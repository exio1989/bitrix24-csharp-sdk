using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Bitrix24RestApiClient.Core.Models;
using Bitrix24RestApiClient.Core.Utilities;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Core.Models.RequestArgs;
using Bitrix24RestApiClient.Core.Builders.Interfaces;
using Bitrix24RestApiClient.Core.Models.CrmAbstractEntity;

namespace Bitrix24RestApiClient.Core.Builders
{
    public class ListRequestBuilder<TEntity> : IListRequestBuilder<TEntity>, IStageHistoriesListRequestBuilder<TEntity>, IListAllRequestBuilder<TEntity>
    {
        private int? entityTypeId;
        private int? start;
        private bool selectAll;
        private List<string> select = new List<string>();
        private List<Filter> filter = new List<Filter>();
        private List<Order> order = new List<Order>();

        public ListRequestBuilder(){
        }

        public ListRequestBuilder(int? entityTypeId, int? start, bool selectAll, List<string> select, List<Filter> filter, List<Order> order)
        {
            this.entityTypeId = entityTypeId;
            this.start = start;
            this.selectAll = selectAll;
            this.select = select;
            this.filter = filter;
            this.order = order;
        }

        public IListRequestBuilder<TEntity> SetEntityTypeId(EntityTypeIdEnum entityTypeId)
        {
            this.entityTypeId = entityTypeId.EntityTypeId;
            return this;
        }

        public IListRequestBuilder<TEntity> SetEntityTypeId(int? entityTypeId)
        {
            this.entityTypeId = entityTypeId;
            return this;
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
        public ListRequestBuilder<TEntity> ClearSelect()
        {
            selectAll = false;
            select.Clear();
            return this;
        }

        public ListRequestBuilder<TEntity> ClearOrderBy()
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

        public IListRequestBuilder<TEntity> AddFilter(Expression<Func<TEntity, object>> nameExpr, object value, FilterOperator op = FilterOperator.Default)
        {
            AddFilterInternal(nameExpr, value, op);
            return this;
        }

        IListAllRequestBuilder<TEntity> IListAllRequestBuilder<TEntity>.AddFilter(Expression<Func<TEntity, object>> nameExpr, object value, FilterOperator op)
        {
            AddFilterInternal(nameExpr, value, op);
            return this;
        }

        public IListRequestBuilder<TEntity> AddPhoneFilter(string phone, FilterOperator op = FilterOperator.Default)
        {
            AddPhoneFilterInternal(phone, op);
            return this;
        }

        IListAllRequestBuilder<TEntity> IListAllRequestBuilder<TEntity>.AddPhoneFilter(string phone, FilterOperator op)
        {
            AddPhoneFilterInternal(phone, op);
            return this;
        }

        public IListRequestBuilder<TEntity> AddEmailFilter(string phone, FilterOperator op = FilterOperator.Default)
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
            return new ListRequestBuilder<TEntity>(entityTypeId, start, selectAll, select.ToList(), filter.ToList(), order.ToList());
        }

        public CrmEntityListRequestArgs BuildArgs()
        {
            if (selectAll)
            {
                select.Add("*");
                select.Add("UF_*");
            }

            var args = new CrmEntityListRequestArgs();

            args.EntityTypeId = entityTypeId;
            args.Select = select;
            args.Start = start;

            foreach (var filterItem in filter)
                args.Filter.Add(filterItem.NameWithOperatorPrefix, filterItem.Value);

            foreach (var orderItem in order)
                args.Order.Add(orderItem.Name, orderItem.direction == OrderDirection.ASC ? "ASC" : "DESC");

            return args;
        }

        private void AddFilterInternal(Expression<Func<TEntity, object>> nameExpr, object value, FilterOperator op)
        {
            var matchedFilter = filter.FirstOrDefault(x => x.Name == nameExpr.JsonPropertyName() && x.Operator == op);
            if (matchedFilter != null)
                filter.Remove(matchedFilter);

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
