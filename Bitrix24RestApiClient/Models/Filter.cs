using Bitrix24ApiClient.src.Models;

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
                    default:
                        return "";
                }
            }
        }
    }
}
