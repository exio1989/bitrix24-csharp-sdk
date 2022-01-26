namespace Bitrix24ApiClient.src.Models.Crm.Core
{
    public class Email: CrmMultiField
    {
        public Email(string email, string emailType)
        {
            TypeId = "EMAIL";
            Value = email;
            ValueType = emailType;
        }
    }
}
