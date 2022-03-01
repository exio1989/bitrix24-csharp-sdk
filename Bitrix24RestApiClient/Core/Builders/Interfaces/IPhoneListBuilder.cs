using Bitrix24RestApiClient.Core.Builders.Interfaces;
using Bitrix24RestApiClient.Core.Models.Enums;

namespace Bitrix24RestApiClient.Core.Builders.Interfaces
{
    public interface IPhoneListBuilder
    {
        IPhoneListBuilder SetField(string phone, string type = EmailType.Рабочий);
    }
}
