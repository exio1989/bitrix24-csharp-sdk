namespace Bitrix24ApiClient.src.Models.Crm.Core
{
    public class Phone: CrmMultiField
    {
        public Phone(string phone, string phoneType)
        {
            TypeId = "PHONE";
            Value = phone;
            ValueType = phoneType;
        }
    }
}
