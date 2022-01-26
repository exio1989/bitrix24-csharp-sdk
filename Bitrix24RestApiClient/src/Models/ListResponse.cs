using System.Collections.Generic;

namespace Bitrix24ApiClient.src.Models
{
    public class ListResponse<TEntity>
    {
        public List<TEntity> Result { get; set; }
        public int Next { get; set; }
        public int Total { get; set; }
    }
}
