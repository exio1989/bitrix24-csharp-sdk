using System.Collections.Generic;

namespace Bitrix24ApiClient.src.Models
{
    public class ListRequestArgs {
        // Набор фильтров, по которым будет идти поиск
        public List<Filter> Filter { get; set; } = new List<Filter>();

        // Список полей, значения которых надо вернуть
        public List<string> Select { get; set; } = new List<string>();

        // Порядок сортировки возвращаемых данных
        public List<Order> Order { get; set; } = new List<Order>();

        // Смещение
        public int? Start { get; set; }
    }
}
