using Bitrix24ApiClient.src.Models;
using System;

namespace Bitrix24ApiClient.src
{
    public class Filter {
        public string Name { get; set; }
        public object Value { get; set; }
        public FilterOperator Operator { get; set; } = FilterOperator.Equal;

        public string NameWithOperatorPrefix {
            get{
                return $"{OperatorPrefix}{Name}";
            }
        }

        private string OperatorPrefix
        {
            get
            {
                switch (Operator)
                {
                    case FilterOperator.GreateThan:
                        return ">";
                    case FilterOperator.LessThan:
                        return "<";
                    case FilterOperator.GreateThanOrEqual:
                        return ">=";
                    case FilterOperator.LessThanOrEqual:
                        return "<=";
                    case FilterOperator.InArray:
                        return "@";
                    case FilterOperator.NotInArray:
                        return "!@";
                    case FilterOperator.Substring:
                        return "%";
                    case FilterOperator.NotEqual:
                        return "!";
                    case FilterOperator.NotSubstring:
                        return "!%";
                    case FilterOperator.Like:
                        return "=%";
                    case FilterOperator.Equal:
                        return "";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
