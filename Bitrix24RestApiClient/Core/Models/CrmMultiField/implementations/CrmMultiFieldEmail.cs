namespace Bitrix24RestApiClient.Core.Models.CrmMultiField.implementations
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
