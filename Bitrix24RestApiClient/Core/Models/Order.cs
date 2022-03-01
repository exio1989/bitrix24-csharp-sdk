namespace Bitrix24RestApiClient.Core.Models
{
    public record Order(string Name, OrderDirection direction = OrderDirection.ASC);
}
