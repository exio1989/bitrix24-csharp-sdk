using Bitrix24RestApiClient.Core.Builders.Interfaces;
using Bitrix24RestApiClient.Core.Models.Enums;

namespace Bitrix24RestApiClient.Core.Builders.Interfaces
{
    public interface IEmailListBuilder
    {
        IEmailListBuilder SetField(string email, string type = EmailType.Рабочий);
    }
}
