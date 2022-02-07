using Bitrix24ApiClient.src.Models.Crm.Core;

namespace Bitrix24ApiClient.src.Builders
{
    public interface IPhoneListBuilder
    {
        IPhoneListBuilder SetField(string phone, string type = EmailType.Рабочий);
    }
}
