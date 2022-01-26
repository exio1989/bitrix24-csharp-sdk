using Bitrix24ApiClient.src.Models;

namespace Bitrix24ApiClient.src
{
    public record Filter(string Name, string Value, FilterOperator Operator = FilterOperator.Equal);
}
