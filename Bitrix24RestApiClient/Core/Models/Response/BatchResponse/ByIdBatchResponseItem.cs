namespace Bitrix24ApiClient.src.Models
{
    public class ByIdBatchResponseItem<TResult>
    {
        public TResult Result { get; set; }
        public int Id { get; set; }
    }
}
