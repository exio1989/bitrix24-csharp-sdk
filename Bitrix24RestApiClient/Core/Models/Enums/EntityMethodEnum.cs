namespace Bitrix24ApiClient.src.Models
{
    public class EntityMethod
    {
        public string Value { get; private set; }

        public static EntityMethod None = new EntityMethod { Value = "" };
        public static EntityMethod List = new EntityMethod { Value = "list" };
        public static EntityMethod Add = new EntityMethod { Value = "add" };
        public static EntityMethod Update = new EntityMethod { Value = "update" };
        public static EntityMethod Delete = new EntityMethod { Value = "delete" };
        public static EntityMethod Search = new EntityMethod { Value = "search" };
        public static EntityMethod Get = new EntityMethod { Value = "get" };
        public static EntityMethod Fields = new EntityMethod { Value = "fields" };
        public static EntityMethod Set = new EntityMethod { Value = "set" };
    }
}
