namespace Bitrix24ApiClient.src.Models
{
    public enum EntityMethodEnum
    {
        List = 0,
        Add = 1,
        Update = 2,
        Delete = 3,
        Search = 4,
        Get = 5,
        Fields = 6,
        Set = 7
    }

    public static class EntityMethod
    {
        public const string List = "list";
        public const string Add = "add";
        public const string Update = "update";
        public const string Delete = "delete";
        public const string Search = "search";
        public const string Get = "get";
        public const string Fields = "fields";
        public const string Set = "set";
    }
}
