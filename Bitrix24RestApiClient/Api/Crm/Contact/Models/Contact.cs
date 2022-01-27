using Bitrix24ApiClient.src.Models.Crm.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bitrix24ApiClient.src.Models
{
    public class Contact
    {
        [JsonProperty(ContactFields.Id)]
        public string Id { get; set; }

        [JsonProperty(ContactFields.Name)]
        public string Name { get; set; }

        [JsonProperty(ContactFields.Email)]
        public List<Email> Emails { get; set; }

        [JsonProperty(ContactFields.Phone)]
        public List<Phone> Phones { get; set; }
    }
}
