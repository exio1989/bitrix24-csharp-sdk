using Bitrix24ApiClient.src.Models.Crm.Core;

namespace Bitrix24ApiClient.src.Builders
{
    public interface IEmailListBuilder
    {
        IEmailListBuilder SetField(string email, string type = EmailType.Рабочий);
    }
}
