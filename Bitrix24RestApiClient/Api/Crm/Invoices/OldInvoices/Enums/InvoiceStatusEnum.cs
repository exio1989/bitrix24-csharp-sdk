namespace Bitrix24ApiClient.src.Models
{
    public class InvoiceStatusEnum
    {
        public InvoiceStatusEnum(string statusId)
        {
            StatusId = statusId;
        }

        public string StatusId { get; private set; }

        public static InvoiceStatusEnum Новый = new InvoiceStatusEnum("N");
        public static InvoiceStatusEnum ОтправленКлиенту = new InvoiceStatusEnum("S");
        public static InvoiceStatusEnum Оплачен = new InvoiceStatusEnum("P");
        public static InvoiceStatusEnum НеОплачен = new InvoiceStatusEnum("D");
    }
}
