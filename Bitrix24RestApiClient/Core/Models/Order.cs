namespace Bitrix24ApiClient.src.Models
{
    public record Order(string Name, OrderDirection direction = OrderDirection.ASC);
}
