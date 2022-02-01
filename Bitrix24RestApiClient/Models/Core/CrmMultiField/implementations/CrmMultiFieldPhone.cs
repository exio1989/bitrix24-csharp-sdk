namespace Bitrix24ApiClient.src.Models.Crm.Core
{
    public class CrmMultiFieldPhone: CrmMultiField
    {
        public CrmMultiFieldPhone() { }
        public CrmMultiFieldPhone(string phone, string phoneType)
        {
            TypeId = "PHONE";
            Value = phone;
            ValueType = phoneType;
        }

        public string Phone
        {
            get
            {
                return Value;
            }
        }
    }
}
