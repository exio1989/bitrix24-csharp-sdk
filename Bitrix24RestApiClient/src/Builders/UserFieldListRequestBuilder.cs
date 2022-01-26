using System.Collections.Generic;

namespace Bitrix24ApiClient.src.Builders
{
    public class UserFieldListRequestBuilder
    {
        private Dictionary<string, string> fieldsToAddOrUpdate = new Dictionary<string, string>();

        public UserFieldListRequestBuilder SetField(string fieldName, string value)
        {
            fieldsToAddOrUpdate[fieldName] = value;
            return this;
        }

        public Dictionary<string, string> Get()
        {
            return fieldsToAddOrUpdate;
        }
    }
}
