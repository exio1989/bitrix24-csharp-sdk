using Bitrix24ApiClient.src.Models;
using System.Collections.Generic;

namespace Bitrix24ApiClient.src.Builders
{
    public class ListRequestArgsBuilder
    {
        private ListRequestArgs args = new ListRequestArgs();

        public static ListRequestArgsBuilder Create()
        {
            return new ListRequestArgsBuilder();
        }

        public ListRequestArgsBuilder WithFilter(string name, string value, FilterOperator op = FilterOperator.Equal)
        {
            args.Filter.Add(new Filter(name, value, op));
            return this;
        }

        public ListRequestArgsBuilder WithOrder(string name, OrderDirection dir = OrderDirection.ASC)
        {
            args.Order.Add(new Order(name, dir));
            return this;
        }

        public ListRequestArgsBuilder WithSelect(string name)
        {
            args.Select.Add(name);
            return this;
        }

        public ListRequestArgsBuilder WithOffset(int start)
        {
            args.Start = start;
            return this;
        }
    }
}
