namespace Bitrix24ApiClient.src.Models
{
    public class EntityMethod
    {
        public string Method { get; private set; }

        public static EntityMethod List = new EntityMethod { Method = "list.json" };
        public static EntityMethod Add = new EntityMethod { Method = "add.json" };
        public static EntityMethod Update = new EntityMethod { Method = "update.json" };
        public static EntityMethod Delete = new EntityMethod { Method = "delete" };
        public static EntityMethod Search = new EntityMethod { Method = "search.json" };
        public static EntityMethod Get = new EntityMethod { Method = "get.json" };
        public static EntityMethod Fields = new EntityMethod { Method = "fields" };
        public static EntityMethod Set = new EntityMethod { Method = "set.json" };
    }
}
