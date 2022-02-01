namespace Bitrix24ApiClient.src.Models.Crm.Core
{
    public class CrmMultiFieldEmail: CrmMultiField
    {
        public CrmMultiFieldEmail() { }
        public CrmMultiFieldEmail(string email, string emailType)
        {
            TypeId = "EMAIL";
            Value = email;
            ValueType = emailType;
        }
        public string Email
        {
            get
            {
                return Value;
            }
        }
    }
}
